using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    static public Game instance;
    private void Awake()
    {
        instance = this;
    }
    public enum GAME_STATUS
    { 
        Ready,
        Running,
        GameOver
    }

    public GAME_STATUS status;

    public GameObject panelReady;
    public GameObject panelRunning;
    public GameObject panelGameOver;
    public TMP_Text scoreText;
    public TMP_Text endScoreText;
    public TMP_Text ensBestText;
    public Slider HPSlider;
    public float HP = 100f;

    //public PipelineManager pipelineManager;
    public UnitManager unitManager;

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
        HPSlider.value = Mathf.Lerp(this.HPSlider.value, HP, 0.02f);
    }

    public void StartGame()
    {
        score = 0;
        this.status = GAME_STATUS.Running;
        UpdateUI();
        //pipelineManager.StartRun();
        unitManager.StartRun();
        Player.instance.Fly();
    }

    public void UpdateUI()
    {
        this.panelReady.SetActive(this.status == GAME_STATUS.Ready);
        scoreText.SetText(score.ToString());
        this.panelRunning.SetActive(this.status == GAME_STATUS.Running);
        endScoreText.SetText(score.ToString());
        ensBestText.SetText(best.ToString());
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
    }

    public void GetPoint()
    {
        score += 1;
        UpdateUI();
    }

    public void Damage(float damage)
    {
        Debug.Log(damage);
        HP -= damage;
        if (HP <= 0)
        {
            GameOver();
        }
    }
}
