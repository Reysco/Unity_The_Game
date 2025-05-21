using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerMoviment2dWithSkeletalSword : MonoBehaviour
{

    public static PlayerMoviment2dWithSkeletalSword pMove { get; private set; }

    public static float move;

    public static bool blockInput = false;

    [SerializeField] private float moveSpeed = 2.5f;

    [SerializeField] private bool jumping;
    [SerializeField] private float jumpSpeed = 6f;

    [SerializeField] private float ghostJump;


    [SerializeField] public static bool isGrounded;
    public Transform feetPosition;
    [SerializeField] public Vector2 sizeCapsule;
    [SerializeField] public float angleCapsule;
    public LayerMask whatIsGround;

    [SerializeField] private bool attackingBool;

    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animationPlayer;


    public bool doubleAtk, lockAtk = false;


    private void Awake()
    {
        if (pMove == null)
        {
            pMove = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }



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


        //reconhcer o chao
        isGrounded = Physics2D.OverlapCapsule(feetPosition.position, sizeCapsule, CapsuleDirection2D.Horizontal, angleCapsule, whatIsGround);

        if (blockInput == false)
        {

            //Input de movimentação do personagem
            move = Input.GetAxisRaw("Horizontal");

            if (move != 0)
            {
                moveSpeed += 15f * Time.deltaTime;

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (moveSpeed >= 5.5f)
                    {
                        moveSpeed = 5.5f;
                    }
                }
                else if (moveSpeed >= 3.0f)
                {
                    moveSpeed = 3.0f;
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

            //Input do ataque do personagem



            if (Input.GetButtonDown("Fire1") && lockAtk == false)
            {
                attackingBool = true;

                if (Input.GetKey(KeyCode.W))
                {
                    animationPlayer.SetBool("SingleATKGroundUP", true);
                }
                else
                {

                    if (isGrounded)
                    {
                        animationPlayer.SetBool("SingleATKGround", true);
                        animationPlayer.SetBool("SingleATKJump", false);

                        animationPlayer.SetBool("DoubleATKGround", false);
                    }
                    else
                    {
                        animationPlayer.SetBool("SingleATKJump", true);
                        animationPlayer.SetBool("SingleATKGround", false);

                        animationPlayer.SetBool("DoubleATKGround", false);
                    }
                    if (doubleAtk == true)
                    {
                        animationPlayer.SetBool("DoubleATKGround", true);
                        animationPlayer.SetBool("SingleATKGround", false);
                    }
                }

                if (attackingBool == true && isGrounded)
                {
                    moveSpeed = 0;
                }
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
    }
    //Mostrar o colisor de "WhatisGround?"
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0.5f);
        Gizmos.DrawCube(feetPosition.position, sizeCapsule);
    }


    void FixedUpdate()
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
    void EndAnimationATK()
    {
        animationPlayer.SetBool("SingleATKGround", false);
        animationPlayer.SetBool("SingleATKJump", false);
        animationPlayer.SetBool("SingleATKGroundUP", false);

        attackingBool = false;
    }
    void EndAnimationDoubleATK()
    {
        animationPlayer.SetBool("DoubleATKGround", false);
        doubleAtk = false;
        attackingBool = false;
    }

    
    //Personagem levando dano
    public IEnumerator DamagePlayer()
    {
        animationPlayer.SetBool("Damage", true);
        sprite.color = new Color(1f, 0, 0, 1f);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1f, 1f, 1f, 1f);
        animationPlayer.SetBool("Damage", false);

        for(int i=0; i < 4; i++)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.15f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.15f);
        }
        Heart.bc.enabled = true;

    }
    public void PlayerDead()
    {
        animationPlayer.SetBool("Dead", true);
        blockInput = true;
        moveSpeed = 0;

        Heart.bc.enabled = false;
        
    }
    
}




