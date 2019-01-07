using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float maxSpeed = 1f;
    public float speed = 1f;

    private Rigidbody2D rgbd2d;

    // Use this for initialization
    void Start () {
        rgbd2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rgbd2d.AddForce(Vector2.right * speed);
        if (rgbd2d.velocity.x > maxSpeed)
        {
            rgbd2d.velocity = new Vector2(maxSpeed, rgbd2d.velocity.y);
        }
        if (rgbd2d.velocity.x < -maxSpeed)
        {
            rgbd2d.velocity = new Vector2(-maxSpeed, rgbd2d.velocity.y);
        }

        if(rgbd2d.velocity.x > -0.01f && rgbd2d.velocity.x < .01f){
            speed = -speed;
            rgbd2d.velocity = new Vector2(speed, rgbd2d.velocity.y);
        }
        if (speed < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (speed>-0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ionic")
        {
              float yOffset = 0.4f;
            if (transform.position.y + yOffset < col.transform.position.y) {
                col.SendMessage("EnemyJump");
                Destroy(gameObject);
            }else
            {
                col.SendMessage("EnemyKnockBack", transform.position.x);
            }
            
        }
    }
}
