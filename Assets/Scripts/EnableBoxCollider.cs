using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBoxCollider : MonoBehaviour
{
    public BoxCollider2D col;

    public void EnableCollider()
    {
        col.enabled = true;
    }
}
