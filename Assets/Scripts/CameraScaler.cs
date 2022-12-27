using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    Camera mainCam;
    float aspect;
    float aspectMin;
    float dif;
    float newSize;

    //public GameObject ground;
    float gY;

    private void Awake()
    {
        
    }

    private void Start()
    {
        SetRelativeSize();
        //ground.transform.localPosition = new Vector2(transform.localPosition.x, gY);
    }

    private void Update()
    {

        //Debug.Log("Aspect: " + mainCam.aspect);
        //Debug.Log("CamSize: " + mainCam.orthographicSize);
        //Debug.Log("NewSize: " + newSize);
        //Debug.Log("Dif: " + dif);
    }

    void SetRelativeSize()
    {
        mainCam = GetComponent<Camera>();
        aspectMin = 1.249344f;
        dif = mainCam.aspect - aspectMin;
        newSize = dif * -4.98401423582f; //-3.9318334527f = 6.15
        mainCam.orthographicSize = 11.75f;
        mainCam.orthographicSize += newSize;
        gY = -1.46f;
        float newPos = dif * 3.00886785348f;
        gY += newPos;
    }

    void SetGroundPos()
    {
        //ground.
    }

    //min aspect = 1.249344 (5:4) 10.41 cam size
    //max aspect = 2.332808 (21:9) 6.15 cam size
    // size diff = -4.26
    //aspect diff = 1.083464
    //-3.9318334527f

    //min aspect = 1.249344 (5:4) 11.75 cam size 
    //max aspect = 2.332808 (21:9) 6.35 cam size
    // size diff = -5.4
    //aspect diff = 1.083464
    //-4.98401423582

    //min ground y pos = 1.8
    //max ground y pos = -1.46
    //diff 3.26
    //3.00886785348


}
