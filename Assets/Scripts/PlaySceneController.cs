using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySceneController : MonoBehaviour
{
    public static int score;
    public static float startTime = 0;

    public Text timeText;
    public Text scoreText;
    public Text highscoreText;

    public static bool highScore;
    public GameObject newHighscore;

    bool bestTime;
    public Text bestTimeText;

    public GameObject fightText;
    public float fightDelay;

    public GameObject loseBox;

    public static bool started;

    public GameObject blocker;

    public Animator heartAnim;

    private void Awake()
    {

        Application.targetFrameRate = 61;
        started = false;
        startTime = 0;
        score = 0;
        highScore = false;
        highscoreText.text = PlayerPrefs.GetInt("Highscore", 1000).ToString();
        bestTimeText.text = PlayerPrefs.GetInt("Best Time", 30).ToString();
        StartCoroutine("FightWait");
    }
    private void Start()
    {
        timeText.text = ((int)startTime).ToString();
    }

    private void Update()
    {
        score = OlehHitController.points;
        scoreText.text = score.ToString();

        if(HealthController.isDead == false && started == true)
        {
            //Debug.Log("Started");
            startTime += 1 * Time.deltaTime;
            timeText.text = ((int)startTime).ToString();
        }

        if(score > PlayerPrefs.GetInt("Highscore", 1000))
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = score.ToString();
            if (highScore == false)
            {
                highScore = true;
                if (!newHighscore.activeInHierarchy)
                {
                    newHighscore.SetActive(true);
                    newHighscore.GetComponent<Text>().text = "New Highscore";
                }
                else
                {
                    StartCoroutine(HighScoreWait("New Highscore"));
                }
            }
        }

        if (((int)startTime) > PlayerPrefs.GetInt("Best Time", 30))
        {
            PlayerPrefs.SetInt("Best Time", ((int)startTime));
            bestTimeText.text = ((int)startTime).ToString();
            if (bestTime == false)
            {
                bestTime = true;
                if (!newHighscore.activeInHierarchy)
                {
                    newHighscore.SetActive(true);
                    newHighscore.GetComponent<Text>().text = "New Best Time";  
                }
                else
                {
                    StartCoroutine(HighScoreWait("New Best Time"));
                }
            }
        }

        heartAnim.SetBool("tired", SliderColor.tired);
    }

    IEnumerator HighScoreWait(string best)
    {
        while (newHighscore.activeInHierarchy)
        {
            yield return null;
        }
        yield return new WaitForSeconds(.3f);
        newHighscore.SetActive(true);
        newHighscore.GetComponent<Text>().text = best;
    }

    IEnumerator FightWait()
    {
        yield return new WaitForSeconds(fightDelay);
        fightText.SetActive(true);
    }
    public void StartGame()
    {
        started = true;
        blocker.SetActive(false);
    }

    public void AcrtivateLosePanel()
    {
        StartCoroutine("LosePanelDelay");
    }
    IEnumerator LosePanelDelay()
    {
        yield return new WaitForSeconds(.5f);
        AudioController.audioController.Bell(1);
        yield return new WaitForSeconds(1.2f);
        loseBox.SetActive(true);
    }
}
