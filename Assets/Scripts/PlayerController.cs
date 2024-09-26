using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    //-----------Public Variables--------------------------------------------------------------------------------------------------------------
    public Scorecontroller scorecontroller;
    public GameoverController gameoverController;
    public keyCountScript keyCount;

    public Animator animator;                                                   //for animation
    public float speed;                                                         // for running
    public float jump;
    public int buildIndex;
    

    //-----------------Private VAriables  [SerializeField] ------------------------------------------------------------------------------------

    [SerializeField] private float m_JumpForce = 100f;							// Amount of force added when the player jumps.
   // [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    //[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool onGround;                                     // Checks Player is on Ground or Not



    //--------Private Variables---------------------------------------------------------------------------------------------------------------
    private Rigidbody2D rb2d;  // for jump 

   
    //Calling awake function
    private void Awake()
    {
        Debug.Log("Awake called");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

  


    //---------------------Player Movement Detection----------------------------------------------------------------------------------------
    //It is done through Update Function
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Jump");

        //running Player by isBoolen

        //Controlling speed through arrow buttons

        RunAnim(horizontal);
        playhorizontal(horizontal, Vertical);
        JumpAnim(Vertical);
        CrouchAnim();
        //box collieder changer

    }
    //-------------------------------------------------------------------------------------------------------------------------------------

    //-----------Run Animation-------------------------------------------------------------------------------------------------------------
   
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
    //---------------------------------------------------------------------------------------------------------------------------------------
    
    //----------------Jump Animation---------------------------------------------------------------------------------------------------------
    
    // Jump Animatuon
    private void JumpAnim(float Vertical)
    {
       // if (Vertical > 0 && onGround)
        if (Vertical > 0)

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
        onGround = false;
        rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        
    }

    //----------------------Challange- Infinate Jumping-------------------------------------------------------------------------------------
    /*
   
   
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


*/
    //---------------------------------------------------------------------------------------------------------------------------------------

    //------------------Crouch Animation-----------------------------------------------------------------------------------------------------
    private void CrouchAnim()
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
    //----------------------------------------------------------------------------------------------------------------------------------------

    //--------Collecting Keys-----------------------------------------------------------------------------------------------------------------
    public void getKey()
    {
        Debug.Log("player Picked the Key");
        scorecontroller.increaseScore(100);
        keyCount.increasekeyCount(1);
    }
    // deteting collition

    //----------------------------------------------------------------------------------------------------------------------------------------
    //----Player Died while touching Enemy----------------------------------------------------------------------------------------------------
    public void killPlayer()
    {
        Debug.Log("Player Killed By Enemy");
        //Play Death animation
        animator.SetBool("Death", true);
        gameoverController.playerdied();

        //animation events
    }
    //----------------------------------------------------------------------------------------------------------------------------------------


}
