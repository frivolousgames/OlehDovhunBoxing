using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactive : MonoBehaviour
{
    public GameObject activeObject;

    public void SetObjectInactive()
    {
        activeObject.SetActive(false);
    }
}
