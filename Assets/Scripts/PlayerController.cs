using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameHandler gameHandler;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private SpriteRenderer spriteRenderer;
    private bool facingRight = true;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float groundCheckHeight;
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Sprite jumpSprite;
    void Start()
    {
    
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.freezeRotation = true;
        boxCollider2d = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerMovement();
    }

    void FixedUpdate(){


    }

    void HandlePlayerMovement(){

        moveSpeed = 10f;
        jumpSpeed = 50f;

        if(  Input.GetTouch(0).phase == TouchPhase.Began  && rigidbody2d.velocity.y <= 0f ){
            // playerAnimator.SetBool("isJumping",true);
            rigidbody2d.gravityScale = 0f;
            rigidbody2d.velocity = jumpSpeed * Vector2.up;
            // spriteRenderer.sprite = jumpSprite; 
            // Debug.Log("[INFO] Sprite " +spriteRenderer.sprite);

        }

        else if (  Input.GetTouch(0).phase == TouchPhase.Began && rigidbody2d.velocity.y > 0f){
                 rigidbody2d.velocity = -jumpSpeed * Vector2.up;

        }
       
  
            // else {
            //     // playerAnimator.SetBool("isRunning",false);
            //     rigidbody2d.velocity = new Vector2(0,rigidbody2d.velocity.y);
            // } 

    }


    bool isGrounded(){

        groundCheckHeight = 0.01f;

        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center,boxCollider2d.bounds.size,0,Vector2.down,groundCheckHeight,platformLayerMask);
        // Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        gameHandler.gameOver();

        Debug.Log(collision);
    }

}
