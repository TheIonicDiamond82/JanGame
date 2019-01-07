using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonicController : MonoBehaviour {
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public float jumpPower = 6.5f;


    private Rigidbody2D rgbd2d;
    private Animator anim;
    private SpriteRenderer spr;
    private bool jump;
    private bool doubleJump;
    private bool movement = true;
	// Use this for initialization
	void Start () {
        rgbd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Speed",Mathf.Abs(rgbd2d.velocity.x));
        anim.SetBool("Grounded",grounded);
        if (grounded)
        {
            doubleJump = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                jump = true;
                doubleJump = true;

            }else if (doubleJump){
                jump = true;
                doubleJump = false;
            }
           
        }
       
    }

    private void FixedUpdate(){

        Vector3 fixedVelocity = rgbd2d.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded)
        {
            rgbd2d.velocity = fixedVelocity;
        }

        float h = Input.GetAxis("Horizontal");
        if (!movement) h = 0;

        rgbd2d.AddForce(Vector2.right * speed * h);

        if (rgbd2d.velocity.x > maxSpeed){
            rgbd2d.velocity = new Vector2(maxSpeed, rgbd2d.velocity.y);
        }
        if (rgbd2d.velocity.x < -maxSpeed)
        {
            rgbd2d.velocity = new Vector2(-maxSpeed, rgbd2d.velocity.y);
        }

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if(h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (jump){
            rgbd2d.velocity = new Vector2(rgbd2d.velocity.x, 0);
            rgbd2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        
    }

    private void OnBecameInvisible()
    {
        transform.position = new Vector3(-6, -3, 0);
    }

    public void EnemyJump()
    {
        jump = true;
    }
    public void EnemyKnockBack(float enemyPosX)
    {
        jump = true;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rgbd2d.AddForce(Vector2.left * side* jumpPower, ForceMode2D.Impulse);

        movement = false;
        Invoke("EnableMovement", 0.7f);

        spr.color = Color.red;
    }
    void EnableMovement()
    {
        movement = true;
        spr.color = Color.white;
    }
}

