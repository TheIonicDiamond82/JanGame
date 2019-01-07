using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFalling : MonoBehaviour {

    public float fallDelay = 1f;
    public float respawnDelay = 5F;
    private Rigidbody2D rgbd2D;
    private PolygonCollider2D pc2D;
    private Vector3 start;

	// Use this for initialization
	void Start () {
        rgbd2D = GetComponent<Rigidbody2D>();
        pc2D = GetComponent<PolygonCollider2D>();
        start = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ionic")
        {
            Invoke("Fall", fallDelay);
            Invoke("Respawn", fallDelay + respawnDelay);
        }
    }
    void Fall()
    {
        rgbd2D.isKinematic = false;
        pc2D.isTrigger = true;
    }
    void Respawn()
    {
        transform.position = start;
        rgbd2D.isKinematic = true;
        rgbd2D.velocity = Vector3.zero;
        pc2D.isTrigger = false;
    }
}
