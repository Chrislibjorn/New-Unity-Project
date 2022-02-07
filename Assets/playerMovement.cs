using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float Speed;
    public float Jumpheight;
    public LayerMask Mask;
    public SpriteRenderer SR;
    public Animator PlayerAnimator;
    public Rigidbody2D RB;
    private bool _isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hej");
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceToGround = GetComponent<Collider2D>().bounds.extents.y;
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, DistanceToGround + 0.9f, Mask);



        Vector2 movement = new Vector2(RB.velocity.x, RB.velocity.y);
        if (Input.GetKey(KeyCode.A))
        {
            RB.AddForce(new Vector2(-Speed * Time.deltaTime, 0));
            // movement.x = -Speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RB.AddForce(new Vector2(Speed * Time.deltaTime, 0));
            // movement.x = Speed * Time.deltaTime;
        }
        else
        {
            movement.x = 0;
        }
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && (_isGrounded))
        {
            RB.AddForce(new Vector2(0, Jumpheight));
            _isGrounded = false;
        }
        if (movement.y > 2)
        {
            //hopper
            PlayerAnimator.SetBool("Jumping", true);
        }
        else
        {
            PlayerAnimator.SetBool("Jumping", false);
        }
        if (movement.x != 0 )
        {
            //går
            PlayerAnimator.SetBool("Walking", true);
        }
        else
        {
            PlayerAnimator.SetBool("Walking", false);
        }
        if (movement.x > 0)
        {
            SR.flipX = false;
        }
        else if (movement.x < 0)
        {
            SR.flipX = true;
        }
        //Stopper kaninen
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            movement.x = 0;
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            movement.x = 0;
        }
        RB.velocity = movement;
    }

}


