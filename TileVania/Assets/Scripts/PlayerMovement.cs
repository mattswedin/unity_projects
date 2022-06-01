using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Animator myAnimator;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    float defaultGravity;
    bool isMoving = false;
    [SerializeField] float playerSpeed = 3f;
    [SerializeField] float jumpSpeed = 3f;
    [SerializeField] float climbSpeed = 5f;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
   
    void Start()
    {
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        defaultGravity = myRigidbody.gravityScale;
    }

    void Update()
    {
        

        Run();
        FlipSprite();
        ClimbLadder();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        //Stops Mickey from moving on Start
        if (Mathf.Abs(moveInput.x) > Mathf.Epsilon && !(Mathf.Abs(moveInput.y) > Mathf.Epsilon)
        || Mathf.Abs(moveInput.y) > Mathf.Epsilon && !(Mathf.Abs(moveInput.x) > Mathf.Epsilon))
        {
            isMoving = true;
        }
    
    }
 
    void OnJump(InputValue value)
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){ return; }
        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * playerSpeed, myRigidbody.velocity.y);

        if (isMoving)
        {
            myRigidbody.velocity = playerVelocity;
        }
         
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
        
    }

    void ClimbLadder()
    {

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;

        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladders"))) 
        {
            myAnimator.SetBool("isClimbing", false);
            myRigidbody.gravityScale = defaultGravity;
            return ; 
        }

        if (playerHasVerticalSpeed)
        {
            myAnimator.SetBool("isClimbing", true);
        }
        else
        {
            myAnimator.SetBool("isClimbing", false);
        }
        
        myRigidbody.gravityScale = 0f;
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);
        myRigidbody.velocity = climbVelocity;        
    }

}
