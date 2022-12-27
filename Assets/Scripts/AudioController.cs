using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController audioController;

    //Sources
    public AudioSource crowdPlayer;
    public AudioSource crowdCheer;

    public AudioSource[] punchPlayers;
    public AudioSource[] gruntPlayers;

    public AudioSource bellPlayer;

    public AudioSource[] blockPlayers;

    public AudioSource bonusPlayer;
    public AudioSource dieSoundPlayer;

    public AudioSource addUpPlayer;

    public AudioSource finalPlayer;

    //Clips

    public AudioClip[] punches;
    public AudioClip[] whooshes;
    public AudioClip[] grunts;

    public AudioClip[] bellClips;

    public AudioClip[] finalClips;

    private void Awake()
    {
        audioController = this;
    }


    public void Grunt(int playerIndex)
    {
        gruntPlayers[playerIndex].clip = grunts[Random.Range(0, grunts.Length - 1)];
        gruntPlayers[playerIndex].pitch = Random.Range(0.99f, 1.1f);
        gruntPlayers[playerIndex].Play();
    }
    public void Whoosh(int playerIndex, int clipIndex)
    {
        punchPlayers[playerIndex].clip = whooshes[clipIndex];
        punchPlayers[playerIndex].pitch = 1f;
        punchPlayers[playerIndex].Play();
    }
    public void Punch(int playerIndex, int clipIndex)
    {
        punchPlayers[playerIndex].clip = punches[clipIndex];
        punchPlayers[playerIndex].pitch = Random.Range(0.97f, 1.2f);
        punchPlayers[playerIndex].Play();
    }

    public void Bell(int index)
    {
        bellPlayer.clip = bellClips[index];
        bellPlayer.Play();
    }

    public void CrowdCheer()
    {
        crowdCheer.Play();
    }

    public void DieSound()
    {
        dieSoundPlayer.Play();
    }
    public void BonusPlayer()
    {
        bonusPlayer.Play();
    }

    public void Block(int index)
    {
        blockPlayers[index].pitch = Random.Range(.96f, 1.04f);
        blockPlayers[index].Play();
    }

    public void AddUp()
    {
        addUpPlayer.pitch = Random.Range(.99f, 1.02f);
        addUpPlayer.Play();
    }

    public void FinalSounds(int clipIndex)
    {
        finalPlayer.clip = finalClips[clipIndex];
        finalPlayer.Play();
    }
}
