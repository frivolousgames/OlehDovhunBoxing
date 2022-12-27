using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxerController : MonoBehaviour
{
    public Animator bodyRootAnim;
    public Animator bodyAnim;
    public Animator headAnim;
    public Animator armAnimL;
    public Animator armAnimR;
    public Animator armRightAnim;
    public Animator armLeftAnim;

    public static bool isPunching;
    public static bool isBlocking;
    public static bool blocked;
    float midFrame;

    public bool isStill;

    public static bool isStunned;
    public int stunTime;
    public static float stunCount;
    public static float staminaMax = 10; //STAMINA 10
    public GameObject stunnedStars;

    public Slider staminaSlider;
    Animator staminaAnim;

    public static bool isShook;

    public AudioClip loudCheer;

    private void Awake()
    {
        isStill = true;
        isStunned = false;
        isBlocking = false;
        blocked = false;
        isShook = false;
        stunTime = 3;
        stunCount = staminaMax;
    }
    private void Start()
    {
        AnimatorClipInfo armClipInfo = armAnimL.GetCurrentAnimatorClipInfo(0)[0];
        float offset = armClipInfo.clip.length / 2f;
        armAnimL.SetFloat("offset", offset);
        armAnimL.SetTrigger("start");
        armAnimR.SetTrigger("start");
        armRightAnim.SetTrigger("start");
        armLeftAnim.SetTrigger("start");
        staminaAnim = staminaSlider.gameObject.GetComponent<Animator>();
        staminaSlider.maxValue = staminaMax;

        StartCoroutine("StaminaDrain");

    }

    private void Update()
    {
        bodyRootAnim.SetBool("isStill", isStill);

        bodyAnim.SetBool("isPunching", isPunching);
        armAnimL.SetBool("isPunching", isPunching);
        armAnimR.SetBool("isPunching", isPunching);
        armRightAnim.SetBool("isPunching", isPunching);
        armLeftAnim.SetBool("isPunching", isPunching);

        bodyAnim.SetBool("isBlocking", isBlocking);
        armAnimL.SetBool("isBlocking", isBlocking);
        armAnimR.SetBool("isBlocking", isBlocking);
        armRightAnim.SetBool("isBlocking", isBlocking);
        armLeftAnim.SetBool("isBlocking", isBlocking);

        bodyAnim.SetBool("isStunned", isStunned);
        armAnimL.SetBool("isStunned", isStunned);
        armAnimR.SetBool("isStunned", isStunned);
        armRightAnim.SetBool("isStunned", isStunned);
        armLeftAnim.SetBool("isStunned", isStunned);
        bodyRootAnim.SetBool("isStunned", isStunned);

        staminaAnim.SetBool("isStunned", isStunned);
        staminaAnim.SetBool("isDead", HealthController.isDead);
        if(HealthController.isDead == false)
        {
            StunAdder();
            Stunned();
            StunnedStarsActive();
        }
    }

    public void Fight()
    {
        armAnimL.SetTrigger("fight");
        armAnimR.SetTrigger("fight");
        armRightAnim.SetTrigger("fight");
        armLeftAnim.SetTrigger("fight");
        isStill = false;
    }

    public void RightJab()
    {
        if (isPunching == false && isBlocking == false && isStunned == false && HealthController.isDead == false && blocked == false && isShook == false && PlaySceneController.started == true)
        {
            isPunching = true;
            bodyAnim.SetTrigger("jab");
            armRightAnim.SetTrigger("jab");
            AudioController.audioController.Whoosh(0, 0);
            OlehController.playerJabbing = true;
        }
    }

    public void RightUpper()
    {
        if (isPunching == false && isBlocking == false && isStunned == false && HealthController.isDead == false && blocked == false && isShook == false && PlaySceneController.started == true)
        {
            isPunching = true;
            bodyAnim.SetTrigger("upper");
            armRightAnim.SetTrigger("upper");
            AudioController.audioController.Whoosh(0, 2);
            AudioController.audioController.Grunt(0);
            OlehController.playerUppering = true;
        }
    }

    public void RightCross()
    {
        if (isPunching == false && isBlocking == false && isStunned == false && HealthController.isDead == false && blocked == false && isShook == false && PlaySceneController.started == true)
        {
            isPunching = true;
            bodyAnim.SetTrigger("cross");
            armRightAnim.SetTrigger("cross");
            AudioController.audioController.Whoosh(0, 1);
            AudioController.audioController.Grunt(0);
            OlehController.playerCrossing = true;
        }
    }

    public void LeftJab()
    {
        if (isPunching == false && isBlocking == false && isStunned == false && HealthController.isDead == false && blocked == false && isShook == false && PlaySceneController.started == true)
        {
            isPunching = true;
            bodyAnim.SetTrigger("jab");
            armLeftAnim.SetTrigger("jab");
            AudioController.audioController.Whoosh(0, 0);
            OlehController.playerJabbing = true;
        }
    }

    public void LeftUpper()
    {
        if (isPunching == false && isBlocking == false && isStunned == false && HealthController.isDead == false && blocked == false && isShook == false && PlaySceneController.started == true)
        {
            isPunching = true;
            bodyAnim.SetTrigger("upper");
            armLeftAnim.SetTrigger("upper");
            AudioController.audioController.Whoosh(0, 2);
            AudioController.audioController.Grunt(0);
            OlehController.playerUppering = true;
        }
    }

    public void LeftCross()
    {
        if (isPunching == false && isBlocking == false && isStunned == false && HealthController.isDead == false && blocked == false && isShook == false && PlaySceneController.started == true)
        {
            isPunching = true;
            bodyAnim.SetTrigger("cross");
            armLeftAnim.SetTrigger("cross");
            AudioController.audioController.Whoosh(0, 1);
            AudioController.audioController.Grunt(0);
            OlehController.playerCrossing = true;
        }
    }

    public void Block()
    {
        if(isPunching == false && isBlocking == false && isStunned == false && HealthController.isDead == false && blocked == false && isShook == false && PlaySceneController.started == true)
        {
            isBlocking = true;
        }
    }
    public void BlockRelease()
    {
        if(isBlocking == true)
        {
            isBlocking = false;
        }
    }

    public void IsBlocked()
    {
        if(blocked == true)
        {
            blocked = false;
        }
        else
        {
            blocked = true;
        }
    }

    IEnumerator AnimPause()
    {
        yield return new WaitForSeconds(.01f);
        AnimatorClipInfo clipInfo = armAnimL.GetCurrentAnimatorClipInfo(0)[0];
        midFrame = clipInfo.clip.length / 2;
        //Debug.Log("Midframe: " + midFrame);
        //Debug.Log("IsBlocking: " + isBlocking);
        yield return new WaitForSeconds(midFrame);
        bodyAnim.speed = 0;
        armAnimL.speed = 0;
        armAnimR.speed = 0;
        armLeftAnim.speed = 0;
        armRightAnim.speed = 0;
    }

    //STUNNED

    IEnumerator StaminaDrain()
    {
        while(HealthController.isDead == false)
        {
            while(PlaySceneController.started == true && isStunned == false)
            {
                stunCount -= .042f;
                yield return new WaitForSeconds(.1f);
            }
            yield return null;
        }
    }
    void Stunned()
    {
        if (stunCount < .1f)
        {
            if (isStunned == false)
            {
                isStunned = true;
                if(isBlocking == true)
                {
                    BlockRelease();
                }
                StartCoroutine("StunnedTime");
            }
        }
    }
    IEnumerator StunnedTime()
    {
        for (int i = 0; i < stunTime; i++)
        {
            OlehController.stunTime = i;
            yield return new WaitForSeconds(1f);
        }
        isStunned = false;
        OlehController.stunTime = 0;
        stunCount = staminaMax;
        //staminaSlider.value = 10f;
    }

    void StunAdder()
    {
        staminaSlider.value = stunCount;
    }

    IEnumerator StunRecover()
    {
        while(isStunned == false)
        {
            if(stunCount < staminaMax)
            {
                yield return null;
            }
        }
    }

    void StunnedStarsActive()
    {
        if(isStunned == true)
        {
            stunnedStars.SetActive(true);
        }
        else
        {
            stunnedStars.SetActive(false);
        }
    }
    public void Nothing()
    {

    }

    public void Shook()
    {
        if (isBlocking == false && blocked == false && isShook == false && PlaySceneController.started == true)
        {
            bodyAnim.SetTrigger("shook");
            armAnimL.SetTrigger("shook");
            armAnimR.SetTrigger("shook");
            isPunching = false;
            isBlocking = false;
            blocked = false;
        }
    }
    public void IsShook()
    {
        if (isShook == true)
        {
            isShook = false;
        }
        else
        {
            isShook = true;
        }
    }


    public void Knockout()
    {
        isStunned = false;
        if (isBlocking == true)
        {
            BlockRelease();
        }
        StopCoroutine("StunnedTime");
        isStill = true;
        stunnedStars.SetActive(false);
        bodyAnim.SetTrigger("knockout");
        armRightAnim.SetTrigger("knockout");
        armLeftAnim.SetTrigger("knockout");
        armAnimL.SetTrigger("knockout");
        armAnimR.SetTrigger("knockout");

        AudioController.audioController.crowdCheer.clip = loudCheer;
        AudioController.audioController.CrowdCheer();

    }


}
