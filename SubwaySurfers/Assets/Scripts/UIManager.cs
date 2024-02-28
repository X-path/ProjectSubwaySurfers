using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum GameState
{
    Stop,
    Play,
    Fail
}
public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    public GameState GState;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject restartPanel;
    public int coin;
    public int score;
    float currentScore = 0;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    private void Start()
    {
        GetCoinandScore();
    }
    void GetCoinandScore()
    {
        if (!PlayerPrefs.HasKey("Coin"))
        {
            PlayerPrefs.SetInt("Coin", coin);
        }
        else
        {
            coin = PlayerPrefs.GetInt("Coin");
            coinText.text = coin.ToString();
        }

        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", score);
        }
        else
        {
            score = PlayerPrefs.GetInt("Score");
            scoreText.text = score.ToString();
        }
    }

    public void ScoreIncrease()
    {
        
        currentScore += 2 * Time.deltaTime;
        score = ((int)currentScore);
        scoreText.text = score.ToString();

    }
    public void CoinIncrease()
    {
        coin += 1;
        coinText.text = coin.ToString();
    }
    void SetCoinandScore()
    {
        PlayerPrefs.SetInt("Coin", coin);
        PlayerPrefs.SetInt("Score", score);
    }
    public void StartButton()
    {
        GState = GameState.Play;
        startPanel.gameObject.SetActive(false);

    }
    public void RestartButton()
    {
        restartPanel.gameObject.SetActive(false);
        SetCoinandScore();
        SceneManager.LoadScene(0);
    }
    public void Died()
    {
        GState = GameState.Fail;
        restartPanel.gameObject.SetActive(true);
    }
}
