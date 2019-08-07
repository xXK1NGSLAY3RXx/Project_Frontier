using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playermovement;
    public CharacterController2D controller;
    private Rigidbody2D rb;
    float horizontalMove = 0f;
    public float RunSpeed = 30f;
    private float Baserunspeed;
    public float dashspeed = 30f;
    private float dashtime = 0;
    public float maxdashtime = 0.5f;
    private bool isdashing = false;

    
  
    
    private bool jump = false;
    private bool jumpflag = false;
    public Animator animator;
    [SerializeField]
    public int lastDir=0;


    private void Start()
    {
        playermovement = this;
        Baserunspeed = RunSpeed;
       
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Debug.Log(dashtime);
        if (Input.GetKeyDown(KeyCode.D))
        {
            lastDir = 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            lastDir = -1;
        }
        if (isdashing == true)
        {
            Baserunspeed = 0;
            dash();
            animator.SetBool("IsDashing",true);
            dashtime += Time.deltaTime;

        }
         if (dashtime >= maxdashtime)
        {
            Baserunspeed = RunSpeed;
            isdashing = false;
            animator.SetBool("IsDashing", false);
            dashtime = 0f;
        }
        //if (start == true)
        //{
        //    dashtime += Time.deltaTime;
            
        //}
        //if (dashtime <= 0)
        //    {
        //        animator.SetBool("IsDashing", false);
        //        start = false;
        //        dashtime = 0.5f;
        //    }



        horizontalMove = Input.GetAxisRaw("Horizontal") * Baserunspeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (jumpflag)
        {
            animator.SetBool("IsJumping", true);
            jumpflag = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
           
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
          if (dashtime < maxdashtime && isdashing == false)
            {
                
                isdashing = true;
            }
            
        }
        //if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    if (isdashing == true)

        //        dashtime = maxdashtime;
        //        isdashing = false;
        //}


    }
    public void dash()
    {
        if (lastDir == 1)
        {
            rb.AddForce(Vector2.right * dashspeed );
        }
        else if (lastDir == -1)
        {
            rb.AddForce(Vector2.left * dashspeed );
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
       

    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        if (jump)
        {
            jumpflag = true;
            jump = false;
        }
    }
}
