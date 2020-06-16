using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private float controlMultiplierWheel = 1f;
    private float controlMultiplierPan = 1f;
    public float panSpeed = 5f;
    public float wheelSpeed = 500f;

    void Start()
    {

    }

    void Update()
    {
        Vector3 pos = transform.position;



        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            controlMultiplierWheel = 5f;
            controlMultiplierPan = 2f;
        }
        else
        {
            controlMultiplierWheel = 1f;
            controlMultiplierPan = 1f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            pos.y += panSpeed * Time.deltaTime * controlMultiplierPan;

            if (pos.y > GlobalVariables.cameraMaxY)
            {
                pos.y -= panSpeed * Time.deltaTime * controlMultiplierPan;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= panSpeed * Time.deltaTime * controlMultiplierPan;

            if (pos.y < GlobalVariables.cameraMinY)
            {
                pos.y += panSpeed * Time.deltaTime * controlMultiplierPan;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= panSpeed * Time.deltaTime * controlMultiplierPan;
            if (pos.x < GlobalVariables.cameraMinX)
            {
                pos.x += panSpeed * Time.deltaTime * controlMultiplierPan;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            pos.x += panSpeed * Time.deltaTime * controlMultiplierPan;
            if (pos.x > GlobalVariables.cameraMaxX)
            {
                pos.x -= panSpeed * Time.deltaTime * controlMultiplierPan;
            }
        }

        float mw = Input.GetAxis("Mouse ScrollWheel");
        if (mw != 0)
        {
            pos.z += Time.deltaTime * mw * wheelSpeed * controlMultiplierWheel;
            if (pos.z < GlobalVariables.cameraMaxZ)
            {
                pos.z = GlobalVariables.cameraMaxZ;
            }
            else if (pos.z > GlobalVariables.cameraMinZ)
            {
                pos.z = GlobalVariables.cameraMinZ;
            }
        }

        transform.position = pos;
    }

}