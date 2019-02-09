using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=5f;
    private Rigidbody2D rb;
    private bool facingRight;
    public bool crouch=false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }


    //Player's movement
    private void Update()
    {
        if (crouch == false)
        {
            Vector3 pos = transform.position;

            
            if (Input.GetKey("d"))
            {
                pos.x += speed * Time.deltaTime;
            }
            if (Input.GetKey("a"))
            {
                pos.x -= speed * Time.deltaTime;
            }


            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position;
            speed = speed / 2;
            
            if (Input.GetKey("d"))
            {
                pos.x += speed * Time.deltaTime;
            }
            if (Input.GetKey("a"))
            {
                pos.x -= speed * Time.deltaTime;
            }


            transform.position = pos;
        }
        //crouch mechanic
        if(Input.GetKey(KeyCode.LeftControl) && crouch==false)
        {
            crouch = true;
            Animator.SetTrigger("Crouch");
        }
        else
            if (Input.GetKey(KeyCode.LeftControl) && crouch == true)
        {
            crouch = false;
            Animator.SetTrigger("Standing");
        }

    }
    //this makes the player turn left or right so that it faces the right direction
    private void Flip(float Horizontal)
    {
        if (Horizontal > 0 && !facingRight || Horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

        }
    }

}
