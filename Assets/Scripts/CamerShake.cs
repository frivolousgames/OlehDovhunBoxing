using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerShake : MonoBehaviour
{
    Vector3 oPos;
    public static bool isShaking;
    public static CamerShake camerShake;

    private void Awake()
    {
        oPos = transform.localPosition;
        camerShake = this;
    }

    public void Shake(float min, float max)
    {
        //if(isShaking == true)
        //{
        //    StopCoroutine(ShakeRoutine());
        //    transform.position = oPos;
        //}
        StartCoroutine(ShakeRoutine(min, max));
    }

    IEnumerator ShakeRoutine(float min, float max)
    {
        isShaking = true;
        for(int i = 0; i < 5; i++)
        {
            transform.position = new Vector3(oPos.x + Random.Range(min, max), oPos.y + Random.Range(min, max), -10f);
            yield return new WaitForSeconds(.05f);
        }
        transform.position = oPos;
        isShaking = false;
        yield break;
    }
}
