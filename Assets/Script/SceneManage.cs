using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public bool GameFinish;
    public bool GameStart;
    public static SceneManage instance;

    // Start is called before the first frame update
    void Start()
    {
        GameFinish = false;
        DontDestroyOnLoad(this);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStart)
        {
            SceneManager.LoadScene("Game");
            GameStart = false;
        }
        if (GameFinish)
        {
            SceneManager.LoadScene("GameOver");
            GameFinish = false;
        }
    }


    public void GameFinishSingnal()
    {
        this.GameFinish = true;
    }
    public void GameStartSignal()
    {
        this.GameStart = true;
    }
}
