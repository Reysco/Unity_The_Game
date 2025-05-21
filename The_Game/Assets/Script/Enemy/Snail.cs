using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class Snail : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sprite;

    private int life = 2;
    public float moveSpeed = 1f;

    public Transform[] pointsToMove;
    public int startingPoint;


    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        transform.position = pointsToMove[startingPoint].transform.position;



    }


    void Update()
    {
        if (startingPoint == 0)
        {
            sprite.flipX = false;
        }
        else if (startingPoint == 1)
        {
            sprite.flipX = true;
        }

          if(life == 1)
          {
              EnemyHidden();
          }else if(life == 0)
          {
              EnemyDead();
          }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointsToMove[startingPoint].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == pointsToMove[startingPoint].transform.position)
        {
            startingPoint++;
        }

        if (startingPoint == pointsToMove.Length)
        {
            startingPoint = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            life--;
        }

    }




    private void EnemyHidden()
    {
        life = 1;
        anim.SetTrigger("Hidden");
        moveSpeed = 0;
        StartCoroutine(EnemyHiddenn());
    }

    private void EnemyDead()
    {
        life = 0;
        anim.SetTrigger("Dead");
        moveSpeed = 0;
        //transform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //transform.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        Destroy(transform.gameObject.GetComponent<BoxCollider2D>());
        Destroy(transform.gameObject.GetComponent<Rigidbody2D>());
        Destroy(this);
    }

    






    public IEnumerator EnemyHiddenn()
    {
        yield return new WaitForSeconds(5f);
        anim.SetTrigger("NotHidden");
        moveSpeed = 0.8f;


    }



}
