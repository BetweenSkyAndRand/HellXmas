using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockContorroler : MonoBehaviour
{
    public static BlockContorroler controller;
    // Start is called before the first frame update
       GameObject block ;
    Rigidbody rigidbody;
    Vector3 FirstPosition = new Vector3(-4f, 1f, 17f);
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * 5 * Time.deltaTime;
        //if(this.transform.position.z<=-30)
        //{
        //    Destroy(this.gameObject);
        //}
        if (this.transform.position.z <= -30)
        {
            Destroy(this.gameObject);
            FlgManager.instance.BlockApeearOFF();
        }

    }
}
