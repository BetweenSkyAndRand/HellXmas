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
        //インスタンスが存在しない場合はこのインスタンスを設定
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);//シーンをまたいでもインスタンスを保持できる
        }
        else
        {
            Destroy(gameObject);//既にインスタンスが存在する場合は新しいインスタンスを破棄
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
