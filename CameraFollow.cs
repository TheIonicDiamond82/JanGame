using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform Ionic;
    public float smoothTime;
    Vector3 desface;
    
    // Use this for initialization
    void Start()
    {
        desface = transform.position - Ionic.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 PositionIonic = Ionic.position + desface;
        transform.position = Vector3.Lerp(transform.position,PositionIonic,smoothTime*Time.deltaTime);
       

    }


}



