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
        //�C���X�^���X�����݂��Ȃ��ꍇ�͂��̃C���X�^���X��ݒ�
        //if (Blockprefab == null)
        
        if(Blockprefab!=null)
        {
            Debug.Log("FlyingCube���݂��Ȃ��琶�������");
            Blockprefab = (GameObject)Resources.Load("FlyingCube");
            DontDestroyOnLoad(Blockprefab);//�V�[�����܂����ł��C���X�^���X��ێ��ł���
        }
        else
        {
            Debug.Log("�u���b�N�������s���s");
            Destroy(Blockprefab);//���ɃC���X�^���X�����݂���ꍇ�͐V�����C���X�^���X��j��
        }
        //else
        //{
        //    Debug.Log("FlyingCube�ǂݍ��߂Ă����");
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
        //        Debug.Log("Cube������܂���");
        //    }
        //    else
        //    {
        //        Debug.Log("Cube���݂����");
        //    }

        //if (appearFlg)
        //{
        //    Instantiate(Blockprefab, new Vector3(3.0f, 1.0f, 10.0f), Quaternion.Euler(0, 0, 0));
        //    appearFlg = false;
        //}
        //Instantiate(Blockprefab, new Vector3(100f + num * BlockManager.boxwide, 1.0f + ((num / BlockManager.numBoxRow) - 1) * BlockManager.boxheight, 7.0f), Quaternion.Euler(0, 90, 0));
        if (FlgManager.instance==null)
        {
            Debug.Log("�u���b�N�t���O�A���݂��܂���I");
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
