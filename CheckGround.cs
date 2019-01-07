using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

    
    private IonicController ionic;
    private Rigidbody2D rgbd2d;

    // Use this for initialization
    void Start() {
        ionic = GetComponentInParent<IonicController>();
        rgbd2d = GetComponent<Rigidbody2D>();


    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            ionic.transform.parent = col.transform;
            ionic.grounded = true;
        }
       
    }
    void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.tag == "Ground")
        {
            ionic.grounded = true;
        }
        if (col.gameObject.tag == "Platform")
        {
            ionic.transform.parent = col.transform;
            ionic.grounded = true;
        }

    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            ionic.grounded = false;
        }
        if (col.gameObject.tag == "Platform")
        {
            ionic.transform.parent = null;
            ionic.grounded = false;
        }
        
    }
}
