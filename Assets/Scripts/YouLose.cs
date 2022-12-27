using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouLose : MonoBehaviour
{
    Animator anim;

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
    }
    public void AnimOffset(float offset)
    {
        anim.SetFloat("offset", offset);
    }
}
