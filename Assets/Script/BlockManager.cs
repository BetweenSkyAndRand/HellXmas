using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    static public float boxwide = 2;//横
    static public float boxheight = 2;//縦の大きさ
    public const int numBoxRow = 5;//列
    public const int numBoxColumn = 2;//行
    int MaxBoxAppearNum = 3;//箱の最大出現集
    int NowBoxAppearNum = 0;//今の箱の出現数
    BlockApeear[] blocks = new BlockApeear[numBoxRow * numBoxColumn];

    bool ready=false;//ここをじかいどうするか
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
        bool readyApeear = true;
        foreach (var block in blocks)
        {
            if (block.appearFlg == true)
            {
                readyApeear = false;
            }
        }
        if (readyApeear)
        {
            //this.ReadyApeear();
        }
        //this.ReadyApeear();
    }
    public void ReadyApeear()
    {
        var BoxNumber = new HashSet<int>();//HashSetは、重複したオブジェクトを追加できないList。Listと違い、順序もは保証されないので注意。
        while (BoxNumber.Count < MaxBoxAppearNum)
        {
            int number = Random.Range(0, numBoxRow * numBoxColumn);
            BoxNumber.Add(number);
        }
        BoxNumber = new HashSet<int> { 1, 4, 6 };
        foreach (var number in BoxNumber)
        {
            blocks[number].Appear(number);//あとここ座標を渡すようにしよう
        }
        //blocks[1].Appear(1);
        //blocks[3].Appear(3);
    }
}
