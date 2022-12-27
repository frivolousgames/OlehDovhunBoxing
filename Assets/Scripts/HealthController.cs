using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public Animator headAnim;
    BoxCollider2D headCol;

    public Slider healthBar;
    public static float maxHealth = 50; //HEALTH 50
    public static float health;

    public GameObject[] jabCol;
    public GameObject[] crossCol;
    public GameObject[] upperCol;
    public GameObject[] finalCol;

    float jabDamage;
    float crossDamage;
    float upperDamage;
    public static float finalDamage;

    public GameObject spit;

    public static bool isDead;

    public UnityEvent knockout;

    public UnityEvent shaken;

    public GameObject olehHeadCol;
    private void Awake()
    {
        isDead = false;
    }

    private void Start()
    {
        headCol = GetComponent<BoxCollider2D>();

        jabDamage = PlayerPrefs.GetFloat("jabDamage", 2);
        crossDamage = PlayerPrefs.GetFloat("crossDamage", 5);
        upperDamage = PlayerPrefs.GetFloat("upperDamage", 7);

        health = maxHealth;
        healthBar.value = health;
    }

    private void Update()
    {
        Die();
        healthBar.value = health;

        jabDamage = PlayerPrefs.GetFloat("jabDamage", 2);
        crossDamage = PlayerPrefs.GetFloat("crossDamage", 5);
        upperDamage = PlayerPrefs.GetFloat("upperDamage", 7);
        finalDamage = PlayerPrefs.GetFloat("finalDamage", 15);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach(GameObject jab in jabCol)
        {
            if (other.gameObject == jab)
            {
                jab.gameObject.SetActive(false);
                SubtractHealth(jabDamage);
                headAnim.SetTrigger("hit");
                headCol.enabled = false;
                AudioController.audioController.Punch(1, 0);
            }
        }
        foreach (GameObject cross in crossCol)
        {
            if (other.gameObject == cross)
            {
                cross.gameObject.SetActive(false);
                SubtractHealth(crossDamage);
                headAnim.SetTrigger("hit");
                headCol.enabled = false;
                spit.SetActive(true);
                CancelPunch();
                AudioController.audioController.Punch(1, 1);
                CamerShake.camerShake.Shake(-.1f, .1f);
            }
        }
            
        foreach (GameObject upper in upperCol)
        {
            if (other.gameObject == upper)
            {
                upper.gameObject.SetActive(false);
                SubtractHealth(upperDamage);
                headAnim.SetTrigger("hit");
                headCol.enabled = false;
                AudioController.audioController.Punch(1, 2);
                AudioController.audioController.CrowdCheer();
                spit.SetActive(true);
                CancelPunch();
                shaken.Invoke();
                CamerShake.camerShake.Shake(-.2f, .2f);
            }
        }
        foreach (GameObject final in finalCol)
        {
            if (other.gameObject == final)
            {
                final.gameObject.SetActive(false);
                SubtractHealth(finalDamage);
                headAnim.SetTrigger("hit");
                headCol.enabled = false;
                AudioController.audioController.Punch(1, 2);
                AudioController.audioController.CrowdCheer();
                spit.SetActive(true);
                CancelPunch();
                shaken.Invoke();
                CamerShake.camerShake.Shake(-.3f, .3f);
            }
        }
    }

    void SubtractHealth(float damage)
    {
        if(health > damage)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
    }

    void Die()
    {
        if(isDead == false)
        {
            if(health == 0)
            {
                isDead = true;
                knockout.Invoke();
            }
        }
    }

    void Spit()
    {
        if (spit.activeInHierarchy)
        {

        }
    }
    void CancelPunch()
    {
        if (BoxerController.isPunching == true && olehHeadCol.activeInHierarchy == true)
        {
            StartCoroutine(ColliderDisable());
        }
    }

    IEnumerator ColliderDisable()
    {
        olehHeadCol.SetActive(false);
        while (BoxerController.isPunching == true)
        {
            yield return null;
        }
        olehHeadCol.SetActive(true);
    }

}
