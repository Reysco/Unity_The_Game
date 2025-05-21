using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{

    PlayerMoviment2dWithSkeletalSword pMove;

    public static BoxCollider2D bc;

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    private void Start()
    {
        pMove = PlayerMoviment2dWithSkeletalSword.pMove;

        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collider)

    {
        //Parte de inimigos

            if (collider.CompareTag("Snail"))
            {
                health--;
                bc.enabled = false;

                if (health > 0)
                {
                    StartCoroutine(pMove.DamagePlayer());
                }else if(health <= 0)
                {
                    pMove.PlayerDead();
                }

        }

        if (collider.CompareTag("Spike"))
        {
            health = health - 10;
            bc.enabled = true;

            pMove.PlayerDead();
        }








        // Parte de Vida
        if (collider.CompareTag("RedHearth"))
        {
            if (health < numOfHearts)
            {
                health++;
            }
        }
        if (collider.CompareTag("GreenHeart"))
        {
            health = health + 2;
        }
        if (collider.CompareTag("BlackHearth"))
        {
            numOfHearts++;
        }

        }

    
}