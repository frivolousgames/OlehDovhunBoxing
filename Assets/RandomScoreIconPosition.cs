using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScoreIconPosition : MonoBehaviour
{
    Vector2 startPos;
    private void Awake()
    {
        startPos = transform.localPosition;
    }
    private void OnEnable()
    {
        transform.localPosition = new Vector2(Random.Range(startPos.x - 20, startPos.x + 20), Random.Range(startPos.y - 20, startPos.y + 20));
    }
}
