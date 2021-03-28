using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
   
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
        //Controlling speed through arrow buttons
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(speed)); //changing speed to abs

        Vector3 scale = transform.localScale; 
        if (speed<0) 
        {
           scale.x = -1f * Mathf.Abs(scale.x); // changig speed to abs
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(speed);
        }
        transform.localScale = scale;
    }
}
