using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerContoroller : MonoBehaviour
{
    public Rigidbody player;
    Vector3 Cameraforward;
    float Horizontal;
    float Vertical;
    float movespeed = 5.2f;
    float JumpForce = 0.7f;
    float GrandCheckDistance=0.5f;
    LayerMask grandLayers = 6;
    float jumptime = 0.0f;
    bool isJumping = false;
    bool isGrand = true;

    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrand = CheckOnGrand();
        if(isGrand)
        {
            //Debug.Log("着地");
            isJumping = false;
        }
        Horizontal = Input.GetAxisRaw("Horizontal");//GetAxisとの違いは、とる値が-1<=x<=1か、-1or0or1かどうか。
        Vertical = Input.GetAxisRaw("Vertical");
        if(!isJumping&&Input.GetKeyDown(KeyCode.Space)&&isGrand)
        {
            isJumping = true;
            jumptime = 0;
        }
        if(transform.position.y<-5)
        {
            SceneManage.instance.GameFinishSingnal();
        }

        //Debug.DrawRay(transform.position + 1f * Vector3.up, Vector3.down);
    }
    private void FixedUpdate()
    {
        
        Cameraforward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1).normalized);
        Vector3 moveForward = Vertical * Cameraforward + Horizontal * Camera.main.transform.right;
        player.velocity = moveForward * movespeed + new Vector3(0, player.velocity.y, 0);
        //player.transform.position = new Vector3(transform.position.x + moveForward.x, -1, transform.position.z + moveForward.z);
        Vector3 AnimDir = moveForward;
        AnimDir.y = 0;
        //方向転換
        //if (AnimDir.sqrMagnitude > 0.001)
        //{
        //    Vector3 newDir = Vector3.RotateTowards(transform.forward, AnimDir, 5f * Time.deltaTime, 0f);
        //    transform.rotation = Quaternion.LookRotation(newDir);
        //}
        Jump();
    }
    public  void ChangeAngle(Vector3 angle)
    {
        this.player.transform.localEulerAngles = angle;
    }
    void Jump()
    {
        if (!isJumping)
        {
            return;           
        }
        if(isGrand)
        {
            player.AddForce(transform.up * JumpForce,ForceMode.Impulse);
        }
        
    }
    bool CheckOnGrand()
    {
        var ray = new Ray(transform.position + Vector3.up * 0.5f, Vector3.down);
        return Physics.Raycast(ray,0.7f);
        //return Physics.SphereCast(transform.position + 0.5f * Vector3.up, 10.0f, Vector3.down, out hit, GrandCheckDistance, grandLayers, QueryTriggerInteraction.Ignore);//Rayキャスト。発射位置と向ききを決めてその方向にRayを飛ばして判定する
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ブロックに接触!!");
        if (other.gameObject.tag=="Bounce")
        {
            Debug.Log("ブロックに接触!!");
            player.AddForce(new Vector3(0, 0, -5));
        }
    }
}
