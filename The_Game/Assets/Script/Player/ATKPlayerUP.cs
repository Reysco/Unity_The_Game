using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKPlayerUP : MonoBehaviour
{

    private BoxCollider2D colliderAtkPlayerUP;

    void Start()
    {
        colliderAtkPlayerUP = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //Inverter posição do colisor de ataque baseado na posição do player
        if (PlayerMoviment2dWithSkeletalSword.move > 0)
        {
            colliderAtkPlayerUP.offset = new Vector2(-0.2f, 0);
        }
        else if (PlayerMoviment2dWithSkeletalSword.move < 0)
        {
            colliderAtkPlayerUP.offset = new Vector2(-0.4f, 0);

        }
    }
}
