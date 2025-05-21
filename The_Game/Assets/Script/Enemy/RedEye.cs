using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RedEye : MonoBehaviour
{
    Heart life;

    public SpriteRenderer sprite;

    public Transform player;
 

    private Rigidbody2D rb;
    private Animator anim;

    public bool Sleeping;
    public bool Acordando;
    public bool Attack;



    public GameObject projecttile;
    private float timeBtwShots;
    public float startTimeBtwShots;


    void Start()
    {
        Sleeping = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        timeBtwShots = startTimeBtwShots;
    }



    private void FixedUpdate()
    {

            //Se o personagem estiver a X distancia do RedEye
            if (Vector3.Distance(transform.position, player.position) < 3.6f)
            {
            Sleeping = false;
            Acordando = true;
            anim.SetBool("Acordando", true);







            //RedEye acorda
                if (Attack == true)
                {
                Acordando = false;

                    anim.SetBool("Attack", true);


                    if (transform.position.x > player.position.x)
                    {
                        sprite.flipX = false;
                    }
                    else
                    {
                        sprite.flipX = true;
                    }
                    if (timeBtwShots <= 0)
                    {
                        Instantiate(projecttile, transform.position, Quaternion.identity);
                        timeBtwShots = startTimeBtwShots;
                    }
                    else
                    {
                        timeBtwShots -= Time.deltaTime;
                    }
                }

            }
            else
            {
            Sleeping = true;
            Attack = false;
            Acordando = false;
                anim.SetBool("Acordando", false);
                anim.SetBool("Attack", false);
            }










    }
    void animationEnded()
    {
        anim.SetBool("Acordando", false);
        Acordando = false;
        Attack = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            Destroy(gameObject);
        }

    }

}

