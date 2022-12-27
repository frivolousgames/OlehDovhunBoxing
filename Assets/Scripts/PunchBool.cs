using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchBool : MonoBehaviour
{
    public void IsPunching()
    {
        BoxerController.isPunching = false;
    }

    public void IsJabbing()
    {
        OlehController.playerJabbing = false;
    }
    public void IsCrossing()
    {
        OlehController.playerCrossing = false;
    }
    public void IsUppering()
    {
        OlehController.playerUppering = false;
    }
}
