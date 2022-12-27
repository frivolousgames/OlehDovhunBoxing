using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlehPunchBool : MonoBehaviour
{
    public void IsPunching()
    {
        OlehController.olehPunching = false;
    }

    public void IsJabbing()
    {
        OlehController.olehJabbing = false;
    }
    public void IsCrossing()
    {
        OlehController.olehCrossing = false;
    }
    public void IsUppering()
    {
        OlehController.olehUppering = false;
    }
    public void IsFinal()
    {
        OlehController.olehFinal = false;
    }
}
