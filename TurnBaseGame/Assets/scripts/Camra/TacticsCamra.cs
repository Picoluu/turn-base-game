using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsCamra : MonoBehaviour {

    public Transform target;
    private Vector3 _camraOffset;
   

    [Range(0.01f, 1f)]
    public float SmoothFactor = 0.5f;
    public bool LookAtTarget = false;
    public bool RotateAroundPlayer = true;
    public float RotationsSpeed = 5f;

    private void Start()
    {
        _camraOffset = transform.position - target.position;
    }


    private void LateUpdate()
    {
        if (RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);
            _camraOffset = camTurnAngle * _camraOffset;
            
        }

        Vector3 newPos = target.position + _camraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        transform.LookAt(target);





    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            
            RotateAroundPlayer = true;
        }
        else
        {
            
            RotateAroundPlayer = false; 

        }

         
    }

}
