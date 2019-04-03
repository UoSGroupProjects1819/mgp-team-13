using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=5f;
    private Rigidbody2D rb;
    private bool facingRight;
    public bool crouching=false;
    public Animator animator;
    public bool right ;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        right = true;
    }


    //Player's movement
    private void Update()
    {
        
        //crouch mechanic
        if(Input.GetKeyUp(KeyCode.LeftControl) && crouching==false)
        {
            crouching = true;
            animator.SetBool("shouldCrouch", true);
            speed = 2f;
        }
        else
            if (Input.GetKeyUp(KeyCode.LeftControl) && crouching == true)
        {
            crouching = false;
            animator.SetBool("shouldCrouch", false);
            speed = 5f;
        }
        

        Vector3 pos = transform.position;


        if (Input.GetKey("d"))
        {
           
            pos.x += speed * Time.deltaTime;
            right = true;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
            right = false;
        }


        transform.position = pos;

        Flip(right);

    }
    //this makes the player turn left or right so that it faces the right direction
    private void Flip(bool right)
    {
        if (right==true && !facingRight || right==false && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

        }
    }
   

}
