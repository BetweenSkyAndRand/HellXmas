using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    static public float boxwide = 2;//��
    static public float boxheight = 2;//�c�̑傫��
    public const int numBoxRow = 5;//��
    public const int numBoxColumn = 2;//�s
    int MaxBoxAppearNum = 3;//���̍ő�o���W
    int NowBoxAppearNum = 0;//���̔��̏o����
    BlockApeear[] blocks = new BlockApeear[numBoxRow * numBoxColumn];

    bool ready=false;//�������������ǂ����邩
    // Start is called before the first frame update
    private void Awake()
    {
        //�C���X�^���X�����݂��Ȃ��ꍇ�͂��̃C���X�^���X��ݒ�
        for(int i=0;i<numBoxRow*numBoxColumn;i++)
        {
            if (blocks[i] == null)
            {
                blocks[i] = FindObjectOfType<BlockApeear>();
                DontDestroyOnLoad(blocks[i]);//�V�[�����܂����ł��C���X�^���X��ێ��ł���
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
        var BoxNumber = new HashSet<int>();//HashSet�́A�d�������I�u�W�F�N�g��ǉ��ł��Ȃ�List�BList�ƈႢ�A�������͕ۏ؂���Ȃ��̂Œ��ӁB
        while (BoxNumber.Count < MaxBoxAppearNum)
        {
            int number = Random.Range(0, numBoxRow * numBoxColumn);
            BoxNumber.Add(number);
        }
        BoxNumber = new HashSet<int> { 1, 4, 6 };
        foreach (var number in BoxNumber)
        {
            blocks[number].Appear(number);//���Ƃ������W��n���悤�ɂ��悤
        }
        //blocks[1].Appear(1);
        //blocks[3].Appear(3);
    }
}
