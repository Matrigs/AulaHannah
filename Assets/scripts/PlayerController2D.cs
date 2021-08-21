using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerController2D : MonoBehaviour
{
    public CharacterController2D controller;
    public GameManager manager;
    public Rigidbody2D rb;
    public Animator animator;
    public float runSpeed;
    public float horizontalMove;
    public bool crouch;
    public bool jump;
    public int points;
    public int energy;
    public TextMeshProUGUI pointsText;

    public TextMeshProUGUI energyText;
    public bool pauseornot = false;
    void Start()
    {
        pointsText.text = "Points: " + points;
        energyText.text = "Energy: " + energy;

       //manager = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    void Update()
    {
       // Debug.Log(Input.GetAxisRaw("Horizontal"));
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jump", true);
        }

        if (Input.GetButtonDown("Crouch") && controller.m_Grounded) 
        {
            crouch = true;
            animator.SetBool("Crouch", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("Crouch", false);
        }

        if (controller.m_Grounded) 
        {
            //jump = false;
            animator.SetBool("Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && pauseornot == false)
        {
            pauseornot = true;
            manager.Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseornot == true) 
        {

            pauseornot = false;
            manager.Unpause();
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        //animator.SetBool("Jump", false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "items")
       {
            points += other.GetComponent<ItemController>().points;
            pointsText.text = "Points: " + points;
            Destroy(other.gameObject);

            energy += other.GetComponent<ItemController>().energy;
            energyText.text = "Energy: " + energy;
            Destroy(other.gameObject);
        }
        if (other.tag == "ENIMY")
        {


            if (energy <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }

        }
    }
    
    void damage(Collider2D other) 
    {
        energy -= other.GetComponent<EnimyController>().damage;
        energyText.text = "Energy: " + energy;

        points -= other.GetComponent<EnimyController>().damage;
        pointsText.text = "Points: " + points;
        if (energy <= 0)
        {

        }
    }
    void die() 
    {
        rb.AddForce(new Vector2(0, 100));
    }
}
