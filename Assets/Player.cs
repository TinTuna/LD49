using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public bool isGrounded = true;
    bool isJumping = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    public Animator anim;
    private SpriteRenderer _renderer;
    public AudioSource jumpAudio;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        if (_renderer == null)
        {
            Debug.LogError("Player Sprite is missing a renderer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        CheckIfGrounded();

    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _renderer.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _renderer.flipX = true;
        }

        // clamp x movement
        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -4.2f, 4.2f), transform.position.y, transform.position.z);
    }
    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("Jump");
            
            JumpAnimCoroutine();
        }
    }
    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (collider != null && !isGrounded && !isJumping) {
            anim.SetTrigger("Land");
            jumpAudio.Play();
        }
        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    IEnumerator JumpAnimCoroutine()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.25f);
        isJumping = false;
    }
}
