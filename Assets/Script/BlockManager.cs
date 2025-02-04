using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    static public float boxwide = 2;//��
    static public float boxlength = 5;//�c�̑傫��
    static public float boxHeight = 2;
    public const int numBoxRow = 5;//��
    public const int numBoxColumn = 2;//�s
    int MaxBoxAppearNum = 10;//���̍ő�o���W
    int NowBoxAppearNum = 3;//���̔��̏o����(�����l3)
    int wave = 0;    
    BlockApeear[] blocks = new BlockApeear[numBoxRow * numBoxColumn];

    bool ready=false;//�������������ǂ����邩
    bool isReadyApeear = true;
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
        var BoxNumber = new HashSet<int>();//HashSet�́A�d�������I�u�W�F�N�g��ǉ��ł��Ȃ�List�BList�ƈႢ�A�����͕ۏ؂���Ȃ��̂Œ��ӁB
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
