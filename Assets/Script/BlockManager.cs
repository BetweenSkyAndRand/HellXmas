using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    static public float boxwide = 2;//横
    static public float boxlength = 5;//縦の大きさ
    static public float boxHeight = 2;
    public const int numBoxRow = 5;//列
    public const int numBoxColumn = 2;//行
    int MaxBoxAppearNum = 10;//箱の最大出現集
    int NowBoxAppearNum = 3;//今の箱の出現数(初期値3)
    int wave = 0;    
    BlockApeear[] blocks = new BlockApeear[numBoxRow * numBoxColumn];

    bool ready=false;//ここをじかいどうするか
    bool isReadyApeear = true;
    // Start is called before the first frame update
    private void Awake()
    {
        //インスタンスが存在しない場合はこのインスタンスを設定
        for(int i=0;i<numBoxRow*numBoxColumn;i++)
        {
            if (blocks[i] == null)
            {
                blocks[i] = FindObjectOfType<BlockApeear>();
                DontDestroyOnLoad(blocks[i]);//シーンをまたいでもインスタンスを保持できる
            }
            else
            {

            }
        }

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isReadyApeear)
        {
            this.ReadyApeear();
            isReadyApeear = false;
            FlgManager.instance.BlockAppearFlgON();
            wave += 1;
            if(wave%5==0&&wave!=0)
            {if (NowBoxAppearNum < MaxBoxAppearNum)
                {
                    NowBoxAppearNum++;
                }
            }
        }
        isReadyApeear = !FlgManager.instance.IsBlockApear();
    }
    public void ReadyApeear()
    {
        var BoxNumber = new HashSet<int>();//HashSetは、重複したオブジェクトを追加できないList。Listと違い、順序は保証されないので注意。
        while (BoxNumber.Count < NowBoxAppearNum)
        {
            int number = Random.Range(1, numBoxRow * numBoxColumn);
            BoxNumber.Add(number);
        }
        //BoxNumber = new HashSet<int> { 1, 4, 6 };
        foreach (var number in BoxNumber)
        {
            Debug.Log(number);
           blocks[number].Appear(number);
        }
    }
}
