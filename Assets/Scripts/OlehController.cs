using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlehController : MonoBehaviour
{
    public Animator bodyRootAnim;
    public Animator bodyAnim;
    public Animator headAnim;
    public Animator armAnimL;
    public Animator armAnimR;
    public Animator armRightAnim;
    public Animator armLeftAnim;

    public static bool olehPunching;
    public static bool olehBlocking;
    public bool blocked;

    public bool isStill;
    public static bool isShook;

    public static int stunTime;

    //FIGHT ROUTINE

    public static bool olehJabbing;
    public static bool olehCrossing;
    public static bool olehUppering;
    public static bool olehFinal;

    public static bool playerJabbing;
    public static bool playerCrossing;
    public static bool playerUppering;

    public static bool playerBlocking;

    bool idleRoutine;
    bool blockRoutine;
    bool stunnedRoutine;

    float blockWait;

    public static int jabAmount;
    float jabTime;
    bool jabbing;

    
    bool counter;
    int counterType;
    int counterCount;

    bool end;

    private void Awake()
    {
        olehBlocking = false;
        olehPunching = false;

        isStill = true;

        olehJabbing = false;
        olehCrossing = false;
        olehUppering = false;
        olehFinal = false;

        playerJabbing = false;
        playerCrossing = false;
        playerUppering = false;

        playerBlocking = false;

        jabbing = false;

        isShook = false;

        counter = false;

        end = false;
        blockWait = 0;
        counterType = 0;
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
    }

    private void Update()
    {
        bodyRootAnim.SetBool("isStill", isStill);

        bodyAnim.SetBool("isPunching", olehPunching);
        armAnimL.SetBool("isPunching", olehPunching);
        armAnimR.SetBool("isPunching", olehPunching);
        armRightAnim.SetBool("isPunching", olehPunching);
        armLeftAnim.SetBool("isPunching", olehPunching);

        bodyAnim.SetBool("isBlocking", olehBlocking);
        armAnimL.SetBool("isBlocking", olehBlocking);
        armAnimR.SetBool("isBlocking", olehBlocking);
        armRightAnim.SetBool("isBlocking", olehBlocking);
        armLeftAnim.SetBool("isBlocking", olehBlocking);

        playerBlocking = BoxerController.isBlocking;

        end = HealthController.isDead;

        Debug.Log("stuntime: " + stunTime);

        //Debug.Log("Counter: " + counter);
        //Debug.Log("End: " + end);
    }

    IEnumerator Blocking()
    {
        yield return new WaitForSeconds(2f);
        Block();
    }

    public void Fight()
    {
        armAnimL.SetTrigger("fight");
        armAnimR.SetTrigger("fight");
        armRightAnim.SetTrigger("fight");
        armLeftAnim.SetTrigger("fight");
        isStill = false;
        idleRoutine = true;
        StartCoroutine(FightRoutine1());
    }

   

    public void RightJab()
    {
        if (olehPunching == false && olehBlocking == false && isShook == false)
        {
            olehPunching = true;
            bodyAnim.SetTrigger("jab");
            armRightAnim.SetTrigger("jab");
            AudioController.audioController.Whoosh(1, 0);
            olehJabbing = true;
        }
    }

    public void RightUpper()
    {
        if (olehPunching == false && olehBlocking == false && isShook == false)
        {
            olehPunching = true;
            bodyAnim.SetTrigger("upper");
            armRightAnim.SetTrigger("upper");
            AudioController.audioController.Whoosh(1, 2);
            AudioController.audioController.Grunt(1);
            olehUppering = true;
        }
    }

    public void RightCross()
    {
        if (olehPunching == false && olehBlocking == false && isShook == false)
        {
            olehPunching = true;
            bodyAnim.SetTrigger("cross");
            armRightAnim.SetTrigger("cross");
            AudioController.audioController.Whoosh(1, 1);
            AudioController.audioController.Grunt(1);
            olehCrossing = true;
        }
    }

    public void LeftJab()
    {
        if (olehPunching == false && olehBlocking == false && isShook == false)
        {
            olehPunching = true;
            bodyAnim.SetTrigger("jab");
            armLeftAnim.SetTrigger("jab");
            AudioController.audioController.Whoosh(1, 0);
            olehJabbing = true;
        }
    }

    public void LeftUpper()
    {
        if (olehPunching == false && olehBlocking == false && isShook == false)
        {
            olehPunching = true;
            bodyAnim.SetTrigger("upper");
            armLeftAnim.SetTrigger("upper");
            AudioController.audioController.Whoosh(1, 2);
            AudioController.audioController.Grunt(1);
            olehUppering = true;
        }
    }

    public void LeftCross()
    {
        if (olehPunching == false && olehBlocking == false && isShook == false)
        {
            olehPunching = true;
            bodyAnim.SetTrigger("cross");
            armLeftAnim.SetTrigger("cross");
            AudioController.audioController.Whoosh(1, 1);
            AudioController.audioController.Grunt(1);
            olehCrossing = true;
        }
    }

    public void Finisher1()
    {
        if (olehPunching == false && olehBlocking == false && isShook == false)
        {
            olehPunching = true;
            bodyAnim.SetTrigger("finisher1");
            armLeftAnim.SetTrigger("finisher1");
            armAnimL.SetTrigger("finisher1");
            armAnimR.SetTrigger("finisher1");
            olehFinal = true;
        }
    }

    public void Finisher2()
    {
        if (olehPunching == false && olehBlocking == false && isShook == false)
        {
            olehPunching = true;
            bodyAnim.SetTrigger("finisher2");
            armLeftAnim.SetTrigger("finisher2");
            armAnimL.SetTrigger("finisher2");
            armAnimR.SetTrigger("finisher2");
            olehFinal = true;
        }
    }

    public void Block()
    {
        if (olehPunching == false && olehBlocking == false && isShook == false)
        {
            olehBlocking = true;
        }
    }
    public void BlockRelease()
    {
        olehBlocking = false;
    }

    public void Shook()
    {
        if(olehBlocking == false && blocked == false && end == false && isShook == false)
        {
            bodyAnim.SetTrigger("shook");
            armAnimL.SetTrigger("shook");
            armAnimR.SetTrigger("shook");
            olehPunching = false;
            olehBlocking = false;
            blocked = false;
        }
    }

    public void Nothing()
    {

    }

    public void IsShook()
    {
        if(isShook == true)
        {
            isShook = false;
        }
        else
        {
            isShook = true;
        }
    }

    public void End()
    {
        StopAllCoroutines();
        if (olehBlocking == true)
        {
            BlockRelease();
        }

        olehCrossing = false;
        olehJabbing = false;
        olehUppering = false;

        playerJabbing = false;
        playerCrossing = false;
        playerUppering = false;

        armAnimL.SetTrigger("end");
        armAnimR.SetTrigger("end");
        armRightAnim.SetTrigger("end");
        armLeftAnim.SetTrigger("end");
        isStill = true;
    }

    IEnumerator Fighting()
    {
        yield return new WaitForSeconds(.5f);
        while (end == false)
        {
            if(olehPunching == false && olehBlocking == false)
            {
                if (BoxerController.isPunching == true && playerBlocking == false && BoxerController.isStunned == false)
                {
                    int i = Random.Range(0, 51);
                    if(i < 21)
                    {
                        if(playerJabbing == true && jabbing == false)
                        {
                            jabbing = true;
                            Block();
                            StartCoroutine(JabCount());
                            while(jabbing == true)
                            {
                                yield return null;
                            }
                            StartCoroutine(BlockWait(0f));
                            yield return null;
                        }
                        else if(playerCrossing == true)
                        {
                            Block();
                            StartCoroutine(BlockWait(.7f));
                            yield return null;
                        }
                        else
                        {
                            Block();
                            StartCoroutine(BlockWait(1f));
                            yield return null;
                        }
                        yield return null;
                    }
                    else if(i >= 21 && i < 51)
                    {
                        if (playerJabbing == true && jabbing == false)
                        {
                            jabbing = true;
                            Block();
                            StartCoroutine(JabCount());
                            while (jabbing == true)
                            {
                                yield return null;
                            }
                            StartCoroutine(BlockWait(0f));
                            yield return null;
                        }
                        else if (playerCrossing == true)
                        {
                            int j = Random.Range(0, 2);
                            {
                                if(j == 0)
                                {
                                    LeftJab();
                                }
                                else
                                {
                                    RightJab();
                                }
                                yield return null;
                            }
                            yield return null;

                        }
                        else
                        {
                            int j = Random.Range(0, 4);
                            if (j == 0)
                            {
                                LeftJab();
                            }
                            else if(j == 1)
                            {
                                RightJab();
                            }
                            else if (j == 2)
                            {
                                LeftCross();
                            }
                            else
                            {
                                RightCross();
                            }
                            yield return null;
                        }
                        yield return null;
                    }
                    yield return null;
                }
                else if (playerBlocking == true)
                {
                    while(playerBlocking == true)
                    {
                        Debug.Log("Blocking");
                        yield return new WaitForSeconds(Random.Range(.4f, 8f));
                        LeftJab();
                        yield return new WaitForSeconds(Random.Range(.4f, .8f));
                        RightJab();
                        yield return null;
                    }
                    yield return null;
                }
                else if(BoxerController.isStunned == true)
                {
                    while(BoxerController.isStunned == true)
                    {
                        RightCross();
                        while(olehCrossing == true)
                        {
                            yield return null;
                        }
                        yield return new WaitForSeconds(.2f);
                        LeftCross();
                        while (olehCrossing == true)
                        {
                            yield return null;
                        }
                        yield return new WaitForSeconds(.2f);
                        RightUpper();
                        while (olehUppering == true)
                        {
                            yield return null;
                        }
                        yield return new WaitForSeconds(.2f);
                        LeftUpper();
                        while (olehUppering == true)
                        {
                            yield return null;
                        }
                        yield return new WaitForSeconds(.2f);
                    }
                    yield return null;
                }
                else
                {
                    while(BoxerController.isPunching == false && BoxerController.isStunned == false && BoxerController.isBlocking == false)
                    {
                        int i = Random.Range(0, 101);
                        if (i < 26)
                        {
                            LeftJab();
                            while (olehJabbing == true)
                            {
                                yield return null;
                            }
                            yield return new WaitForSeconds(Random.Range(.3f, 1f));
                        }
                        else if(i >= 26 && i < 51)
                        {
                            RightJab();
                            while (olehJabbing == true)
                            {
                                yield return null;
                            }
                            yield return new WaitForSeconds(Random.Range(.3f, 1f));
                        }
                        else if (i >= 51 && i < 66)
                        {
                            RightCross();
                            while (olehCrossing == true)
                            {
                                yield return null;
                            }
                            yield return new WaitForSeconds(Random.Range(.3f, 1f));
                        }
                        else if (i >= 66 && i < 81)
                        {
                            LeftCross();
                            while (olehCrossing == true)
                            {
                                yield return null;
                            }
                            yield return new WaitForSeconds(Random.Range(.3f, 1f));
                        }
                        else if (i >= 81 && i < 91)
                        {
                            RightUpper();
                            while (olehUppering == true)
                            {
                                yield return null;
                            }
                            yield return new WaitForSeconds(Random.Range(.3f, 1f));
                        }
                        else
                        {
                            LeftUpper();
                            while (olehUppering == true)
                            {
                                yield return null;
                            }
                            yield return new WaitForSeconds(Random.Range(.3f, 1f));
                        }
                        yield return null;
                    }
                    yield return null;
                }
                yield return null;
            }
            yield return null;
        }
        End();
        yield break;
    }

    IEnumerator BlockWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        BlockRelease();
    }

    public void Blocked()
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
    IEnumerator JabCount()
    {
        while (jabbing == true)
        {
            jabTime += 1;
            if (jabTime > jabAmount || BoxerController.isStunned || end == true)
            {
                jabTime = 0;
                jabAmount = 0;
                jabbing = false;
                yield break;
            }
            else
            {
                yield return new WaitForSeconds(.5f);
            }
        }
        
    }

    IEnumerator FightRoutine()
    {
        yield return new WaitForSeconds(.5f);
        while (end == false)
        {
            while(idleRoutine == true)
            {
                
                int i = Random.Range(0, 100);
                float min = .4f;
                float max = 1f;
                yield return new WaitForSeconds(Random.Range(min, max));

                while (olehPunching == true)
                {
                    yield return null;
                }
                if (BoxerController.isPunching == true)
                {
                    idleRoutine = false;
                    blockRoutine = true;
                    yield return null;
                    break;
                }
                else if(isShook == true)
                {
                    while(isShook == true)
                    {
                        yield return null;
                        Debug.Log("SHOOK");
                    }
                    yield return null;
                }
                else if(BoxerController.isStunned == true)
                {
                    idleRoutine = false;
                    //stunnedRoutine = true;
                    yield return null;
                    break;
                }
                else if (HealthController.isDead == true)
                {
                    idleRoutine = false;
                    end = true;
                    yield return null;
                    break;
                }
                else if(i < 51)
                {
                    if(i % 2 == 0)
                    {
                        LeftJab();
                        yield return null;
                    }
                    else
                    {
                        RightJab();
                        yield return null;
                    }
                }
                else if (i >= 51 && i < 81)
                {
                    if (i % 2 == 0)
                    {
                        LeftCross();
                        yield return null;
                    }
                    else
                    {
                        RightCross();
                        yield return null;
                    }
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        LeftUpper();
                        yield return null;
                    }
                    else
                    {
                        RightUpper();
                        yield return null;
                    }
                }              
            }
            while(blockRoutine == true)
            {
                int i = Random.Range(0, 100);
                if (isShook == true)
                {
                    while (isShook == true)
                    {
                        yield return null;
                    }
                    yield return null;
                }
                
                else if(i < 34)
                {
                    if (isShook == true)
                    {
                        while (isShook == true)
                        {
                            yield return null;
                        }
                        yield return null;
                    }
                    Block();
                    StartCoroutine(BlockWait(1f));
                    while(blocked == true)
                    {
                        yield return null;
                    }
                    RightJab();
                    while(olehPunching == true)
                    {
                        yield return null;
                    }
                    LeftJab();
                    while (olehPunching == true)
                    {
                        yield return null;
                    }
                    blockRoutine = false;
                    idleRoutine = true;
                    yield return null;
                    break;
                }
                else if(i >= 34 && i < 67)
                {
                    if (isShook == true)
                    {
                        while (isShook == true)
                        {
                            yield return null;
                        }
                        yield return null;
                    }
                    Block();
                    while(olehBlocking == true)
                    {
                        if (BoxerController.isStunned == true)
                        {
                            StartCoroutine(BlockWait(0f));
                            while (blocked == true)
                            {
                                yield return null;
                            }
                            yield return null;
                            break;
                        }
                        if (playerJabbing == true)
                        {
                            jabbing = true;
                            jabAmount = 1;
                            jabTime = 0;
                            while(jabbing == true)
                            {
                                if (BoxerController.isStunned == true)
                                {
                                    StartCoroutine(BlockWait(0f));
                                    while (blocked == true)
                                    {
                                        yield return null;
                                    }
                                    jabbing = false;
                                    yield return null;
                                    break;
                                }
                                if (playerJabbing == true)
                                {
                                    jabAmount++;
                                    yield return null;
                                }
                                jabTime++;
                                if(jabTime > jabAmount)
                                {
                                    jabTime = 0;
                                    jabAmount = 0;
                                    StartCoroutine(BlockWait(0f));
                                    while(blocked == true)
                                    {
                                        yield return null;
                                    }
                                    jabbing = false;
                                    idleRoutine = true;
                                    yield return null;
                                    break;
                                }
                                //yield return new WaitForSeconds(.3f);
                                yield return null;
                            }
                            yield return null;
                        }
                        else
                        {
                            StartCoroutine(BlockWait(.4f));
                            while (blocked == true)
                            {
                                yield return null;
                            }
                            idleRoutine = true;
                            yield return null;
                            break;
                        }
                        yield return null;
                    }
                    yield return null;
                }
                else
                {
                    if (isShook == true)
                    {
                        while (isShook == true)
                        {
                            yield return null;
                        }
                        yield return null;
                    }
                    LeftJab();
                    while (olehPunching == true)
                    {
                        yield return null;
                    }
                    RightJab();
                    while(olehPunching == true)
                    {
                        yield return null;
                    }
                    LeftUpper();
                    while (olehPunching == true)
                    {
                        yield return null;
                    }
                    blockRoutine = false;
                    idleRoutine = true;
                    yield return null;
                    break;
                }
            }
            while (BoxerController.isStunned == true)
            {
                RightCross();
                while (olehCrossing == true)
                {
                    yield return null;
                }
                yield return new WaitForSeconds(.2f);
                LeftCross();
                while (olehCrossing == true)
                {
                    yield return null;
                }
                yield return new WaitForSeconds(.2f);
                RightUpper();
                while (olehUppering == true)
                {
                    yield return null;
                }
                yield return new WaitForSeconds(.2f);
                LeftUpper();
                while (olehUppering == true)
                {
                    yield return null;
                }
                yield return new WaitForSeconds(.2f);
            }
            idleRoutine = true;
            yield return new WaitForSeconds(.2f);
            //while(isShook == true)
            //{
            //    yield return null;
            //}
            //yield return null;
        }
        End();
        yield return null;
    }

    IEnumerator FightRoutine1()
    {
        counterCount = 0;
        yield return new WaitForSeconds(.5f);
        while (end == false)
        {
            counterCount++;

            if(counterCount > 70 && counter == false)
            {
                counter = true;
                counterType = Random.Range(0, 5);
                counterCount = 0;
                yield return null;
            }
            /////////////Block//////////////
            if(BoxerController.isPunching == true)
            {
                counterCount = 0;
                if(blocked == false)
                {
                    Block();
                    if (playerCrossing == true)
                    {
                        blockWait = .9f; counterType = Random.Range(1, 8);
                    }
                    else if (playerUppering == true)
                    {
                        blockWait = .6f; counterType = Random.Range(2, 8);
                    }
                    else
                    {
                        blockWait = .3f; counterType = Random.Range(0, 4);
                    }
                    yield return new WaitForSeconds(blockWait);
                }
                else
                {
                    olehBlocking = true;
                    if (playerCrossing == true)
                    {
                        blockWait = .9f; counterType = Random.Range(1, 9);
                    }
                    else if (playerUppering == true)
                    {
                        blockWait = .6f; counterType = Random.Range(2, 9);
                    }
                    else
                    {
                        blockWait = .3f; counterType = Random.Range(0,4);
                    }
                    yield return new WaitForSeconds(blockWait);
                }
            }
            else
            {
                /////////UnBlock///////////
                if (olehBlocking == true)
                {
                    BlockRelease();
                    while(blocked == true)
                    {
                        yield return null;
                    }
                    counter = true;
                }

                yield return null;
            }
            while(counter == true)
            {
                /////////Counter Punch/////////
                counterCount = 0;
                switch (counterType)
                {
                    case 0:
                        RightJab();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        break;
                    case 1:
                        RightJab();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        LeftJab();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        break;
                    case 2:
                        RightCross();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        break;
                    case 3:
                        LeftJab();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        RightJab();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        LeftUpper();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        break;
                    case 4:
                        RightJab();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        RightJab();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        LeftCross();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        break;
                    case 5:
                        RightJab();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        LeftJab();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        RightCross();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        LeftUpper();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        break;
                    case 6:
                        LeftUpper();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        RightUpper();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        break;
                    case 7:
                        RightCross();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        LeftCross();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        break;
                    case 8:
                        yield return new WaitForSeconds(.8f);
                        break;
                    default:
                        LeftJab();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        RightJab();
                        while (olehPunching == true)
                        {
                            yield return null;
                        }
                        break;
                }
                counter = false;
                yield return null;
            }
            while(BoxerController.isStunned == true)
            {
                if (olehBlocking == true)
                {
                    BlockRelease();
                    while (blocked == true)
                    {
                        yield return null;
                    }
                    yield return null;
                }
                ////////Stunned//////////
                ///
                if(HealthController.health < HealthController.finalDamage && stunTime < 1)
                {
                    int i = Random.Range(0, 2);
                    if(i == 0)
                    {
                        Finisher2();
                    }
                    else
                    {
                        Finisher1();
                    }
                    while (olehPunching == true)
                    {
                        yield return null;
                    }
                }
                else
                {
                    LeftCross();
                    while (olehPunching == true)
                    {
                        yield return null;
                    }
                    yield return new WaitForSeconds(.2f);
                    RightCross();
                    while (olehPunching == true)
                    {
                        yield return null;
                    }
                    yield return new WaitForSeconds(.2f);
                    LeftUpper();
                    while (olehPunching == true)
                    {
                        yield return null;
                    }
                    yield return new WaitForSeconds(.2f);
                    RightUpper();
                    while (olehPunching == true)
                    {
                        yield return null;
                    }
                    yield return new WaitForSeconds(.2f);
                }
                yield return null;
            }
            yield return null;
        }
        End();
        yield return null;
    }
    //OLEH:
    //isPunching
    //isBlocking

    //PLAYER:
    //isPunching playerPunching
    ////isJabbing playerJabbingRoutine
    ////isCrossing playerCrossingRoutine
    ////isUppering playerUpperingRoutine
    ///
    //isBlocking playerBlockingRoutineutine
    //isStunned playerStunnedRoutine
}
