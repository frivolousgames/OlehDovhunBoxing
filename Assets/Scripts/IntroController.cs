using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    int resetLimit = 0;
    public GameObject bg;

    public Animator anim;
    public GameObject introSong;
    bool end;

    public AudioSource punchPlayer;

    public void StartGame()
    {
        anim.SetTrigger("end");
        introSong.SetActive(false);
    }

    public void LoadLevel()
    {
        StartCoroutine(PunchSound());  
    }

    IEnumerator PunchSound()
    {
        punchPlayer.Play();
        while (punchPlayer.isPlaying)
        {
            yield return null;
        }
        SceneManager.LoadScene("Play");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetData()
    {
        if(resetLimit < 10)
        {
            resetLimit++;
        }
        else
        {
            PlayerPrefs.DeleteAll();
            StartCoroutine(Blink());
        }
    }
    IEnumerator Blink()
    {
        bg.SetActive(false);
        yield return new WaitForSeconds(.1f);
        bg.SetActive(true);
        yield return new WaitForSeconds(.1f);
        bg.SetActive(false);
        yield return new WaitForSeconds(.1f);
        bg.SetActive(true);
        yield return null;
    }
}
