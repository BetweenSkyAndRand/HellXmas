using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (FlgManager.instance.IsBlockApear())
        {
            FlgManager.instance.BlockApeearOFF();
        }
        else
        {
            Debug.Log("�u���b�N�o����");
        }
    }
}
