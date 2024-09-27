using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    static public Game instance;
    public int currentLevelID = 1;
    public bool GameSuccess = false;
    

    private void Awake()
    {
        instance = this;
    }
    public enum GAME_STATUS
    { 
        Ready,
        Running,
        GameOver,
        GameSuccess,
    }

    public GAME_STATUS status;

    public GameObject panelReady;
    public GameObject panelRunning;
    public GameObject panelGameOver;
    public TMP_Text scoreText;
    public TMP_Text endScoreText;
    public TMP_Text ensBestText;
    public TMP_Text isSuccess;
    public Slider HPSlider;
    public float MAX_HP = 500f;
    public float HP = 500f;

    //public PipelineManager pipelineManager;
    public UnitManager unitManager;
    public LevelManager levelManager;
    public Player player;

    public int score;
    public int best;

    public GAME_STATUS Status 
    { 
        get { return status; }
        set { status = value; }
    }
    void Start()
    {
        this.status = GAME_STATUS.Ready;
        UpdateUI();
        best = PlayerPrefs.GetInt("Best");

        
    }
    private void Update()
    {
        HPSlider.value = Mathf.Lerp(this.HPSlider.value, this.HP, 0.02f);
    }

    public void StartGame()
    {
        score = 0;
        this.status = GAME_STATUS.Running;
        UpdateUI();
        //pipelineManager.StartRun();
        //unitManager.StartRun();
        Player.instance.Fly();

        this.levelManager.unitManager = this.unitManager;
        this.levelManager.currentplayer = this.player;
        this.levelManager.LoadLevel(this.currentLevelID);
    }

    public void UpdateUI()
    {
        this.panelReady.SetActive(this.status == GAME_STATUS.Ready);
        scoreText.SetText(score.ToString());
        this.panelRunning.SetActive(this.status == GAME_STATUS.Running);
        endScoreText.SetText(score.ToString());
        ensBestText.SetText(best.ToString());
        if (this.GameSuccess)
            isSuccess.SetText("你 过 关！");
        else
            isSuccess.SetText("菜就多练");
        this.panelGameOver.SetActive(this.status == GAME_STATUS.GameOver);
    }
    public void GameOver()
    {
        if (best < score)
        {
            best = score;
            PlayerPrefs.SetInt("Best", best);
        }
        Time.timeScale = 0;
        this.status = GAME_STATUS.GameOver;
        UpdateUI();
    }

    public void ReStartGame()
    {
        score = 0;
        //PipelineManager.instance.DestoryAllPipes();
        Time.timeScale = 1;
        this.status = GAME_STATUS.Running;
        UpdateUI();
        Player.instance.Fly();
        HP = MAX_HP;
    }

    public void GetPoint(int value)
    {
        score += value;
        UpdateUI();
    }

    public void flashHP(float HP)
    {
        this.HP = HP;
        if (this.HP <= 0)
        {
            GameOver();
        }
    }
}
