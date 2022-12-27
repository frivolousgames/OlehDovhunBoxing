using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlehArmSounds : MonoBehaviour
{
    // Start is called before the first frame update
    public void ArmWhoosh()
    {
        AudioController.audioController.FinalSounds(1);
        Debug.Log("WHOOSH");
    }

    public void FinalWhoosh()
    {
        AudioController.audioController.FinalSounds(1);
        Debug.Log("WHOOSH");
    }
}
