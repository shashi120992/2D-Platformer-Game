using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public Scorecontroller scorecontroller;
    public GameoverController gameoverController;

    public Animator animator; //for animation
    public float speed;        // for running
    public float jump;
    public float jumpForce;
    public int buildIndex;



    private bool onGround;
    private Rigidbody2D rb2d;  // for jump 

    public void killPlayer()
    {
        Debug.Log("Player Killed By Enemy");
        //Destroy(gameObject);
        //Play Death animation
        animator.SetBool("Death", true);
        gameoverController.playerdied();

        //Reset entire level
        //reloadLevel();
    }

   

    //Calling awake function
    private void Awake()
    {
        Debug.Log("Awake called");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void getKey()
    {
        Debug.Log("player Picked the Key");
        scorecontroller.increaseScore(100);
       
    }

    // deteting collition

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Jump");

        //running Player by isBoolen

        //Controlling speed through arrow buttons

        RunAnim(horizontal);
        playhorizontal(horizontal, Vertical);
        JumpAnim(Vertical);
        Crouch();
        //box collieder changer

    }

    private void Crouch()
    {
        //crouching animation

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", false);

        }
        else
        {
            animator.SetBool("isCrouch", true);
        }
    }

    private void RunAnim(float horizontal)
    {
        //move charector horizontally
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //checking if player felldown
        if (position.y < -7.5)
        {
            SceneManager.LoadScene(buildIndex);
        }



    }


    private void playhorizontal(float horizontal, float Vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal)); //changing speed to abs

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x); // changig speed to abs
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(horizontal);
        }
        transform.localScale = scale;

    }
    // Jump Animatuon
    private void JumpAnim(float Vertical)
    {
        if (Vertical > 0 && onGround)
        {
            animator.SetBool("Jump", true);
            Jump();
        }
        else
        {
            animator.SetBool("Jump", false);
        }

    }
    void Jump()
    {
        //rb2d.velocity = Vector2.up * jumpForce;
        onGround = false;
        rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
    }


   
    //to compare ground while jumping
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }




}
