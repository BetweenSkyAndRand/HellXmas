using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlgManager : MonoBehaviour
{
    public static FlgManager instance;
    bool BlockAppear;
    // Start is called before the first frame update
    private void Awake()
    {
        //�C���X�^���X�����݂��Ȃ��ꍇ�͂��̃C���X�^���X��ݒ�
        if (instance == null)
        {
            instance = this;
            Debug.Log("�C���X�^���X����");
            DontDestroyOnLoad(gameObject);//�V�[�����܂����ł��C���X�^���X��ێ��ł���
        }
        else
        {
            Debug.Log("�C���X�^���X���s");
            Destroy(gameObject);//���ɃC���X�^���X�����݂���ꍇ�͐V�����C���X�^���X��j��
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsBlockApear()
    {
        return BlockAppear;
    }
    public void BlockAppearFlgON()
    {
        this.BlockAppear = true;
    }
    public void BlockApeearOFF()
    {
        this.BlockAppear = false;
    }
    
}
