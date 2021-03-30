using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator; //for animation
    public float speed;        // for running
   
    //Calling awake function
    private void Awake()
    {
        Debug.Log("Awake called");
    }

    // deteting collition
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colission: + " + collision.gameObject.name);
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");


        //running Player by isBoolen

        //Controlling speed through arrow buttons

        movecharector(horizontal);
        playhorizontal(horizontal);

        //crouching animation
        // animator.SetBool("isCrouch")
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", false);

        }
        else animator.SetBool("isCrouch", true);
        //box collieder changer

    }

    private void movecharector(float horizontal)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void playhorizontal(float horizontal)
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
}