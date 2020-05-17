using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static bool isStart;

    public GameObject overMenu;
    public GameObject startMenu;

    public GameObject bird;
    public GameObject pipe;

    public Text textScore;
    public Text endScore;
    public Text bestScore;
    int score;

    public AudioSource overSound;

    void Awake()
    {
        IsStartGameForTheFirstTime();
    }
    void Start () {
        startMenu.SetActive(true);
        overMenu.SetActive(false);

        bird.GetComponent<Rigidbody2D>().simulated = false;
        pipe.SetActive(false);

        endScore.enabled = false;
        textScore.gameObject.SetActive(false);
        score = 0;

        isStart = false;
        
    }
	
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void StartGame()
    {
        startMenu.SetActive(false);
        bird.GetComponent<Rigidbody2D>().simulated = true;
        pipe.SetActive(true);
        textScore.gameObject.SetActive(true);
        isStart = true;
    }
    public void GetScore()
    {
        textScore.text = (++score).ToString();
    }
    public void GameOver()
    {
        GrassMove.grassMoveSpeed = 0;
        PipeController.pipeMoveSpeed = 0;

        if (score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);   
        }
        StartCoroutine(WaitForShowOver(0.5f));
    }
    IEnumerator WaitForShowOver(float duration)
    {
        yield return new WaitForSeconds(duration);
        overSound.Play();
        overMenu.SetActive(true);
        endScore.text = "SCORE\n" + score.ToString();
        bestScore.text = "BEST\n" + PlayerPrefs.GetInt("BestScore"); 

        textScore.enabled = false;
        endScore.enabled = true;
        bestScore.enabled = true;
    }
    void IsStartGameForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsStartGameForTheFirstTime"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
            PlayerPrefs.SetInt("IsStartGameForTheFirstTime", 0);
        }
    }
}
