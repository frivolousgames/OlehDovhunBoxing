using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject[] punches;
    public static bool blocked;
    public float hitWait;

    private void OnDisable()
    {
        blocked = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach(GameObject p in punches)
        {
            if(other.gameObject == p)
            {
                //if(hit == false)
                {
                    BoxerController.stunCount -= .15f;
                    //other.gameObject.SetActive(false);
                    AudioController.audioController.Block(1);
                    blocked = true;
                    //Debug.Log("blocked");
                    StartCoroutine(HitReset());
                }
            }
        }
    }

    IEnumerator HitReset()
    {
        yield return new WaitForSeconds(hitWait);
        blocked = false;
        Debug.Log("reset");

    }
}
