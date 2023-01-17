using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroController : MonoBehaviour
{
    int resetLimit = 0;
    public GameObject bg;

    public Animator anim;
    public GameObject introSong;
    bool end;

    public AudioSource punchPlayer;

    public GameObject videoCanvas;

    public VideoPlayer vidPlayer;
    public VideoClip[] vidClips;

    public GameObject blockerPanel;

    bool started;

    public void StartGame()
    {
        if(started == false)
        {
            StartCoroutine("PlayVideo");
            started = true;
        }
    }

    IEnumerator PlayVideo()
    {
        anim.SetTrigger("mute");
        introSong.SetActive(false);
        videoCanvas.SetActive(true);
        int i = Random.Range(0, vidClips.Length);
        vidPlayer.clip = vidClips[i];
        vidPlayer.Prepare();
        while (!vidPlayer.isPrepared)
        {
            Debug.Log("Prepping...");
            yield return null;
        }
        vidPlayer.Play();
        while (vidPlayer.isPlaying)
        {
            Debug.Log("PLaying...");
            yield return null;
        }
        //videoCanvas.SetActive(false);
        blockerPanel.SetActive(true);

        anim.SetTrigger("end");
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

    public void OpenSpotify()
    {
        Application.OpenURL("https://linktr.ee/yinzworld");
        //https://podcasts.apple.com/us/podcast/yinz-world/id1634614209 https://open.spotify.com/show/4Z37CsR7DEIv1fPQjocgzd
    }
}
