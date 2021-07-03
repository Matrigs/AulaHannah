using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnimyController : MonoBehaviour
{
    //public CharacterController2D controller;
    public float runSpeed;
    
    public bool facingRight;

    public Rigidbody2D rb2d;

    public int damage;


    // Start is called before the first frame update
    void Start() 
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(runSpeed * Time.deltaTime, rb2d.velocity.y);
        if (runSpeed > 0 && !facingRight)
        {
            Flip();
        }
        else if (runSpeed < 0 && facingRight)
        {
            Flip();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "colisor of eagle")
        {
                runSpeed *= -1;
        }

        if (other.tag == "hit box") 
        {
            Destroy(gameObject);
        }

    }
    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
