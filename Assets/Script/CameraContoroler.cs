using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class CameraContoroler : MonoBehaviour
{
    private Vector3 angle;
    private Vector3 primary_angle;
    GameObject camera;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        var angle = this.gameObject.transform.localEulerAngles;
        primary_angle = this.gameObject.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        ////ƒ}ƒEƒX
        //float xMove = Input.GetAxis("Mouse X");
        //float yMove = Input.GetAxis("Mouse Y");
        //float maxLimit = 60;
        //float minLimit = 360 - maxLimit;
        //X‰ñ“]
        angle.y += Input.GetAxis("Mouse X");


        angle.x -= Input.GetAxis("Mouse Y");
        if (angle.x <= primary_angle.x - 20f)
        {
            angle.x = primary_angle.x - 20;
        }
        if (angle.x >= primary_angle.x + 40f)
        {
            angle.x = primary_angle.x + 40f;
        }
        //Y‰ñ“]
        this.gameObject.transform.localEulerAngles = angle;
    }

}
