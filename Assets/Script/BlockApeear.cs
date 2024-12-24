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
        if (Blockprefab == null)
        {
            Blockprefab = (GameObject)Resources.Load("FlyingCube");
            DontDestroyOnLoad(Blockprefab);//シーンをまたいでもインスタンスを保持できる
        }
        else
        {
            Destroy(Blockprefab);//既にインスタンスが存在する場合は新しいインスタンスを破棄
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
            Debug.Log("Cube見つかりません");
        }
      //  Instantiate(Blockprefab, new Vector3(1.0f, 2.0f, 1.0f), new Quaternion(0, 0, 0, 0));
        if (FlgManager.instance==null)
        {
            Debug.Log("ブロックフラグ、存在しません！");
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
