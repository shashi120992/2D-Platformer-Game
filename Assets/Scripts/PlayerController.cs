using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator; //for animation
    public float speed;        // for running
    public float jump;
    private bool onGround;
    private Rigidbody2D rb2d;  // for jump 
   
    //Calling awake function
    private void Awake()
    {
        Debug.Log("Awake called");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // deteting collition
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colission: + " + collision.gameObject.name);
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Jump");

        //running Player by isBoolen

        //Controlling speed through arrow buttons

        movecharector(horizontal, Vertical);
        playhorizontal(horizontal, Vertical);
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

    private void movecharector(float horizontal, float Vertical)
    {
       //move charector horizontally
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        // move charector vertically
        if (Vertical > 0)
        //if (Vertical > 0 & onGround)
         {
            //onGround = false;
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
        
    }
   
    //-------------------------------------------------------------------------------
    //Not Working
    //
    //to compare ground while jumping
    //private void OncollisionEnterEnter2D(Collision2D collision)
    // {
    //    if(collision.gameObject.CompareTag("Ground"))
    //    {
    //        onGround = true;
    //    }
    //}

   // private void OnCollisionExit2D(Collision2D collision)
   // {
   //    if (collision.gameObject.CompareTag("Ground"))
   //     {
   //         onGround = false;
   //     }
   // }
   //---------------------------------------------------------------------------------

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

        //Jump animation   (To be moved to new void)
        
        if(Vertical>0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
            
    }
}