using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunAdder : MonoBehaviour
{
    public GameObject[] punches;
    bool hit;
    public float hitWait;

    private void OnDisable()
    {
        hit = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach(GameObject p in punches)
        {
            if(other.gameObject == p)
            {
                if(hit == false)
                {
                    BoxerController.stunCount -= .2f;
                    other.gameObject.SetActive(false);
                    AudioController.audioController.Block(0);
                    hit = true;
                    StartCoroutine(HitReset());
                }
            }
        }
    }

    IEnumerator HitReset()
    {
        yield return new WaitForSeconds(hitWait);
        hit = false;
    }
}
