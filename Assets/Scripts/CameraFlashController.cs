using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlashController : MonoBehaviour
{
    GameObject[] flashes;
    bool flashing;

    AudioSource click;
    private void Awake()
    {
        flashing = true;
    }

    private void Start()
    {
        click = GetComponent<AudioSource>();
        flashes = GameObject.FindGameObjectsWithTag("Camera Flash");
        foreach(GameObject flash in flashes)
        {
            flash.SetActive(false);
        }
        StartCoroutine("FlashActivator");
    }

    IEnumerator FlashActivator()
    {
        while(flashing == true)
        {
            while (HealthController.isDead != true)
            {
                yield return new WaitForSeconds(Random.Range(.1f, 1f));
                int flash = Random.Range(0, flashes.Length - 1);
                flashes[flash].SetActive(true);
                click.pitch = Random.Range(.94f, 1.04f);
                click.Play();
                yield return null;
            }
            yield return null;
        }
        
    }
}
