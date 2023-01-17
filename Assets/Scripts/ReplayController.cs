using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class ReplayController : MonoBehaviour
{
    public Animator loseBoxAnim;

    public Text endTimeText;
    public Text endScoreText;

    int time;
    int score;
    int timeBonus;
    int finalScore;

    public float addSpeed = 5f;

    public GameObject blocker;

    public Text highScoreText;
    public GameObject newHighScore;

    bool added;

    public GameObject videoCanvas;
    public VideoPlayer vidPlayer;

    public GameObject crowdPlayer;

    public Animator fadeAnim;
   
    private void Start()
    {
        added = false;
        time = (int)PlaySceneController.startTime;
        timeBonus = time * 10;
        score = PlaySceneController.score;
        endTimeText.text = timeBonus.ToString();
        endScoreText.text = score.ToString();
        StartCoroutine("AddScore");
    }

    private void Update()
    {
        if (score > PlayerPrefs.GetInt("Highscore", 1000))
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = score.ToString();
            if (PlaySceneController.highScore == false)
            {
                newHighScore.SetActive(true);
                PlaySceneController.highScore = true;
            }
        }

    }

    IEnumerator AddScore()
    {
        finalScore = score + timeBonus;
        yield return new WaitForSeconds(1f);
        while(timeBonus > 0)
        {
            timeBonus -= 10;
            endTimeText.text = timeBonus.ToString();
            score += 10;
            endScoreText.text = score.ToString();
            PlaySceneController.score = score;
            AudioController.audioController.AddUp();
            yield return new WaitForSeconds(.02f);
        }
        endTimeText.text = "0";
        endScoreText.text = finalScore.ToString();
        added = true;
        blocker.SetActive(false);
        //score += time * 10 * addSpeed * Time.deltaTime;
        //endScoreText.text = score + timeBonus.ToString();
    }



    public void QuitGame()
    {
        StartCoroutine("PlayVideo");
    }

    IEnumerator PlayVideo()
    {
        crowdPlayer.SetActive(false);
        videoCanvas.SetActive(true);
        vidPlayer.Prepare();
        while (!vidPlayer.isPrepared)
        {
            yield return null;
        }
        vidPlayer.Play();
        while (vidPlayer.isPlaying)
        {
            yield return null;
        }
        Application.Quit();
    }
    
    public void CloseLoseBox()
    {
        if (added == true)
        {
            loseBoxAnim.SetTrigger("close");
        }
    }

    public void AddedQuick()
    {
        if (added == false)
        {
            Debug.Log("ADDED");
            added = true;
            StopAllCoroutines();
            score = finalScore;
            endScoreText.text = finalScore.ToString();
            timeBonus = 0;
            endTimeText.text = "0";
            PlaySceneController.score = score;
            AudioController.audioController.AddUp();
            blocker.SetActive(false);
        }
    }
    public void Retry()
    {
        fadeAnim.SetTrigger("end");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Play");

    }
}
