using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    static Dictionary<string, List<TacticsMove>> units = new Dictionary<string, List<TacticsMove>>();
    //  turnKey will represent the currnt team that her turn is active 
    static Queue<string> turnKey = new Queue<string>();
    // turnTeam will represent the currnt turn of the members of the same team 
    static Queue<TacticsMove> turnTeam = new Queue<TacticsMove>();

	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        if (turnTeam.Count == 0)
        {
            InitTeamTurnQueue();
        }
      
	}

    static void InitTeamTurnQueue()
    {
        List<TacticsMove> teamList = units[turnKey.Peek()];

        foreach (TacticsMove unit in teamList)
        {
            turnTeam.Enqueue(unit);
        }

        StartTurn();
    }

    public static void StartTurn()
    {
        if (turnTeam.Count > 0)
        {
            turnTeam.Peek().BeginTurn();

        }

    }


    public static void EndTurn()
    {
        TacticsMove unit = turnTeam.Dequeue();
        unit.EndTurn();

        if (turnTeam.Count > 0f)
        {
            StartTurn();

        }
        else
        {
            string team = turnKey.Dequeue();
            turnKey.Enqueue(team);
            InitTeamTurnQueue();
        }
    }

    // this func will allow the units to add themselves to the Dictionary units
    // todo create a new class called characters and change the AddUnit func to intake a Character type not a TacticsMove type
    //
    public static void AddUnit(TacticsMove unit)
    {
        //this list will be a part of the Dictionary 
        List<TacticsMove> list;

        if (!units.ContainsKey(unit.tag))
        {
            // adding a team with the tag to the Dictionary
            list = new List<TacticsMove>();
            units[unit.tag] = list;
            // adding the team to the turn que 
            if (!turnKey.Contains(unit.tag))
            {
                turnKey.Enqueue(unit.tag);
            }

        }
        else
        {
            // regardless if there are units in the Dictionary at the end of this statment there will be a list in the Dictionary 
            list = units[unit.tag];

        }
        list.Add(unit);
    }

    //todo: if a unit is defeated or killed it needs to be removed from the list.
    // will need to add a remove unit func to remove it from the queue.
    // and if its the last memeber of a team it will need to be removed form the turnKey aswell.

}
