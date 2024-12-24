using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerContoroller : MonoBehaviour
{
   public  Rigidbody player;
    Vector3 Cameraforward;
    float Horizontal;
    float Vertical;
    float movespeed = 5.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        this.player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");//GetAxis�Ƃ̈Ⴂ�́A�Ƃ�l��-1<=x<=1���A-1or0or1���ǂ����B
        Vertical = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        
        Cameraforward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1).normalized);
        Vector3 moveForward = Vertical * Cameraforward + Horizontal * Camera.main.transform.right;
        player.velocity = moveForward * movespeed + new Vector3(0, player.velocity.y, 0);
        //player.transform.position = new Vector3(transform.position.x + moveForward.x, -1, transform.position.z + moveForward.z);

        Vector3 AnimDir = moveForward;
        AnimDir.y = 0;
        //�����]��
        //if (AnimDir.sqrMagnitude > 0.001)
        //{
        //    Vector3 newDir = Vector3.RotateTowards(transform.forward, AnimDir, 5f * Time.deltaTime, 0f);
        //    transform.rotation = Quaternion.LookRotation(newDir);
        //}
    }
    public  void ChangeAngle(Vector3 angle)
    {
        this.player.transform.localEulerAngles = angle;
    }

}
