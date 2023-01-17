using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OlehHitController : MonoBehaviour
{
    public Animator headAnim;

    BoxCollider2D headCol;

    public GameObject[] jabCol;
    public GameObject[] crossCol;
    public GameObject[] upperCol;
    public GameObject[] finalCol;

    public int jabPoints;
    public int crossPoints;
    public int upperPoints;

    public GameObject spit;

    public static int points;

    public GameObject[] bonuses;
    float bonusPoints;

    public GameObject playerHeadCol;

    public UnityEvent shaken;

    public GameObject[] scoreIcons;
    private void Awake()
    {
        points = 0;
    }

    private void Start()
    {
        headCol = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (GameObject jab in jabCol)
        {
            if (other.gameObject == jab)
            {
                OlehController.jabAmount++;
                points += jabPoints;
                headAnim.SetTrigger("hit");
                //Debug.Log("JAB");
                headCol.enabled = false;
                BonusHit(4, 1);
                AudioController.audioController.Punch(0, 0);
                if (scoreIcons[0].activeInHierarchy)
                {
                    scoreIcons[1].SetActive(true);
                }
                else
                {
                    scoreIcons[0].SetActive(true);
                }
            }
        }
        foreach (GameObject cross in crossCol)
        {
            if (other.gameObject == cross)
            {
                points += crossPoints;
                headAnim.SetTrigger("hit");
                headCol.enabled = false;
                AudioController.audioController.Punch(0, 1);
                spit.SetActive(true);
                BonusHit(8, 3);
                CancelPunch();
                //shaken.Invoke();
                CamerShake.camerShake.Shake(-.1f, .1f);
                if (scoreIcons[2].activeInHierarchy)
                {
                    scoreIcons[3].SetActive(true);
                }
                else
                {
                    scoreIcons[2].SetActive(true);
                }
            }
        }
        foreach (GameObject upper in upperCol)
        {
            if (other.gameObject == upper)
            {
                points += upperPoints;
                headAnim.SetTrigger("hit");
                headCol.enabled = false;
                AudioController.audioController.Punch(0, 2);
                AudioController.audioController.CrowdCheer();
                spit.SetActive(true);
                CamerShake.camerShake.Shake(-.2f, .2f);
                CancelPunch();
                shaken.Invoke();
                BonusHit(13, 7);
                if (scoreIcons[4].activeInHierarchy)
                {
                    scoreIcons[5].SetActive(true);
                }
                else
                {
                    scoreIcons[4].SetActive(true);
                }
            }
        }        
    }

    void BonusHit(int amount1, int amount2)
    {
        if (OlehController.olehPunching)
        {
            
            AudioController.audioController.BonusPlayer();
            int i = 0;
            float h = (HealthController.health / HealthController.maxHealth) * 100;
            float s = (BoxerController.stunCount / BoxerController.staminaMax) * 100;

            if (h > s)
            {
                i = 1;
            }
            else
            {
                i = 0;
            }
            //Debug.Log("Health %: " + h);
            //Debug.Log("Stamina %: " + s);
            bonuses[i].SetActive(true);
            if(i == 0)
            {
                bonusPoints = amount1;
                if(HealthController.health < (HealthController.maxHealth - bonusPoints))
                {
                    HealthController.health += bonusPoints;
                }
                else
                {
                    HealthController.health = HealthController.maxHealth;
                }
            }
            else
            {
                bonusPoints = amount2;
                if(BoxerController.stunCount < (BoxerController.staminaMax - bonusPoints))
                {
                    BoxerController.stunCount += bonusPoints;
                }
                else
                {
                    BoxerController.stunCount = BoxerController.staminaMax;

                }
            }
        }
    }
    void CancelPunch()
    {
        if(OlehController.olehPunching == true && playerHeadCol.activeInHierarchy == true)
        {
            StartCoroutine(ColliderDisable());
        }
    }

    IEnumerator ColliderDisable()
    {
        playerHeadCol.SetActive(false);
        while(OlehController.olehPunching == true)
        {
            yield return null;
        }
        playerHeadCol.SetActive(true);
    }
}
