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
        if (Blockprefab == null)
        {
            Blockprefab = (GameObject)Resources.Load("FlyingCube");
            DontDestroyOnLoad(Blockprefab);//�V�[�����܂����ł��C���X�^���X��ێ��ł���
        }
        else
        {
            Destroy(Blockprefab);//���ɃC���X�^���X�����݂���ꍇ�͐V�����C���X�^���X��j��
        }
        
    }
    void Start()
    {
        appearFlg = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Blockprefab == null)
        {
            Debug.Log("Cube������܂���");
        }
      //  Instantiate(Blockprefab, new Vector3(1.0f, 2.0f, 1.0f), new Quaternion(0, 0, 0, 0));
        if (FlgManager.instance==null)
        {
            Debug.Log("�u���b�N�t���O�A���݂��܂���I");
        }
        this.appearFlg = FlgManager.instance.IsBlockApear();
    }
    public void Appear(int num)
    {

        GameObject block = Instantiate(Blockprefab,new Vector3(-4.0f+num*BlockManager.boxwide,1.0f+((num/BlockManager.numBoxRow)-1)*BlockManager.boxheight,7.0f), Quaternion.identity);
        //Instantiate(Blockprefab, new Vector3(1.0f, 2.0f, 1.0f), new Quaternion(0,0,0,0));
        FlgManager.instance.BlockAppearFlgON();
    }
}
