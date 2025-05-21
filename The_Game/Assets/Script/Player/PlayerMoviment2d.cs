using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment2d : MonoBehaviour
{
    private float move;

   

    [SerializeField] private bool TakingSkeletalSwordBool = false;
    [SerializeField] private Transform SkeletalSword;
    [SerializeField] private GameObject PlayerSkeletalSword;

    [SerializeField] private float moveSpeed = 2.5f;

    [SerializeField] private bool jumping;
    [SerializeField] private float jumpSpeed = 6f;

    [SerializeField] private float ghostJump;


    [SerializeField] private bool isGrounded;
    public Transform feetPosition;
    [SerializeField] public Vector2 sizeCapsule;
    [SerializeField] public float angleCapsule;
    public LayerMask whatIsGround;

    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animationPlayer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animationPlayer = GetComponent<Animator>();

        sizeCapsule = new Vector2(0.39f, 0.01f);
        angleCapsule = -90;

    }


    // Update is called once per frame


    void Update()
    {

        if (TakingSkeletalSwordBool == false)
        {




            //reconhcer o chao
            isGrounded = Physics2D.OverlapCapsule(feetPosition.position, sizeCapsule, CapsuleDirection2D.Horizontal, angleCapsule, whatIsGround);


            //Input de movimentação do personagem
            move = Input.GetAxisRaw("Horizontal");

            if (move != 0)
            {
                moveSpeed += 15f * Time.deltaTime;

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (moveSpeed >= 3.5f)
                    {
                        moveSpeed = 3.5f;
                    }
                }
                else if (moveSpeed >= 2.0f)
                {
                    moveSpeed = 2.0f;
                }

            }
            else
            {
                moveSpeed = 0;
            }






            //Input do pulo do personagem
            if (Input.GetButtonDown("Jump") && ghostJump > 0)
            {
                jumping = true;
            }

            //Animação do Personagem
            if (move < 0)
            {
                sprite.flipX = true;
            }
            else if (move > 0)
            {
                sprite.flipX = false;
            }

            if (isGrounded)
            {

                ghostJump = 0.05f;

                animationPlayer.SetBool("JumpingV", false);
                animationPlayer.SetBool("Jumping", false);

                if (rb.velocity.x != 0 && move != 0)
                {
                    animationPlayer.SetBool("Walking", true);
                    animationPlayer.SetBool("FastWalking", false);
                    if (rb.velocity.x > 3.0f || rb.velocity.x < -3.0f)
                    {
                        animationPlayer.SetBool("Walking", false);
                        animationPlayer.SetBool("FastWalking", true);
                    }

                }
                else
                {
                    animationPlayer.SetBool("Walking", false);
                    animationPlayer.SetBool("FastWalking", false);
                }
            }
            else
            {
                ghostJump -= Time.deltaTime;

                if (ghostJump <= 0)
                {
                    ghostJump = 0;
                }

                if (rb.velocity.x == 0)
                {
                    animationPlayer.SetBool("Walking", false);
                    animationPlayer.SetBool("FastWalking", false);

                    if (rb.velocity.y > 0)
                    {
                        animationPlayer.SetBool("JumpingV", true);
                        animationPlayer.SetBool("Jumping", false);
                        animationPlayer.SetBool("Walking", false);
                        animationPlayer.SetBool("FastWalking", false);
                    }
                    if (rb.velocity.y < 0)
                    {
                        animationPlayer.SetBool("JumpingV", true);
                        animationPlayer.SetBool("Jumping", false);
                        animationPlayer.SetBool("Walking", false);
                        animationPlayer.SetBool("FastWalking", false);
                    }

                }


                else
                {
                    if (rb.velocity.y > 0)
                    {
                        animationPlayer.SetBool("JumpingV", false);
                        animationPlayer.SetBool("Jumping", true);
                    }
                    if (rb.velocity.y < 0)
                    {
                        animationPlayer.SetBool("JumpingV", false);
                        animationPlayer.SetBool("Jumping", true);
                    }
                }
            }
        }
        else
        {
            animationPlayer.SetBool("FastWalking", false);
            animationPlayer.SetBool("Walking", false);
            animationPlayer.SetBool("TakingSkeletalSword", true);
        }
    }
    //Mostrar o colisor de "WhatisGround?"
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0.5f);
        Gizmos.DrawCube(feetPosition.position, sizeCapsule);
    }


    void FixedUpdate()
    {
        if (TakingSkeletalSwordBool == false)
        {


            rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

            //Pulo do personagem
            if (jumping)
            {
                rb.velocity = Vector2.up * jumpSpeed;
                // rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);

                jumping = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D Coll)
    {
        if (Coll.gameObject.tag == "SkeletalSword" && isGrounded && Input.GetKey(KeyCode.E))
        {
            TakingSkeletalSwordBool = true;
            sprite.flipX = false;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            rb.velocity = new Vector2(0, 0);
            //essa parte deu erro pq não ficou no quadradinho exato.
            // transform.position = SkeletalSword.position;
        }
    }


    void DestroySkeletalSword()
    {
        Destroy(SkeletalSword.gameObject);
    }

    void DestroyPlayer()
    {
        Instantiate(PlayerSkeletalSword, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        Destroy(gameObject);
    }



}
