using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockApeear : MonoBehaviour
{
    public bool appearFlg=false;

    public GameObject Blockprefab;
    // Start is called before the first frame update
    private void Awake()
    {
        //インスタンスが存在しない場合はこのインスタンスを設定
        //if (Blockprefab == null)
        
        if(Blockprefab!=null)
        {
            Debug.Log("FlyingCube存在しなから生成するよ");
            Blockprefab = (GameObject)Resources.Load("FlyingCube");
            DontDestroyOnLoad(Blockprefab);//シーンをまたいでもインスタンスを保持できる
        }
        else
        {
            Debug.Log("ブロック生成失敗失敗");
            Destroy(Blockprefab);//既にインスタンスが存在する場合は新しいインスタンスを破棄
        }
        //else
        //{
        //    Debug.Log("FlyingCube読み込めているよ");
        //}



    }
    void Start()
    {
        appearFlg =true;        
    }

    // Update is called once per frame
    void Update()
    {
        //    if (Blockprefab == null)
        //    {
        //        Debug.Log("Cube見つかりません");
        //    }
        //    else
        //    {
        //        Debug.Log("Cube存在するよ");
        //    }

        //if (appearFlg)
        //{
        //    Instantiate(Blockprefab, new Vector3(3.0f, 1.0f, 10.0f), Quaternion.Euler(0, 0, 0));
        //    appearFlg = false;
        //}
        //Instantiate(Blockprefab, new Vector3(100f + num * BlockManager.boxwide, 1.0f + ((num / BlockManager.numBoxRow) - 1) * BlockManager.boxheight, 7.0f), Quaternion.Euler(0, 90, 0));
        if (FlgManager.instance==null)
        {
            Debug.Log("ブロックフラグ、存在しません！");
        }
        //this.appearFlg = FlgManager.instance.IsBlockApear();
    }
    public void Appear(int num)
    {
        if(num>5)
        {
            num = num - 5;
            Instantiate(Blockprefab, new Vector3(-4f + (num-1) * BlockManager.boxwide, 1.0f +BlockManager.boxHeight, 7.0f), Quaternion.Euler(0, 0, 0));
        }
        else
        {
             Instantiate(Blockprefab,new Vector3(-4f+ (num-1)* BlockManager.boxwide,1.0f,7.0f), Quaternion.Euler(0,0,0));
        }
        //Instantiate(Blockprefab, new Vector3(1.0f, 2.0f, 1.0f), new Quaternion(0,0,0,0));
        FlgManager.instance.BlockAppearFlgON();
    }
}
