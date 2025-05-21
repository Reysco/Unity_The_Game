using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKPlayer : MonoBehaviour
    
{
    //Reconhecer ataque do player

    private BoxCollider2D colliderAtkPlayer;

    void Start()
    {
        colliderAtkPlayer = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //Inverter posição do colisor de ataque baseado na posição do player
        if(PlayerMoviment2dWithSkeletalSword.move > 0)
        {
            colliderAtkPlayer.offset = new Vector2(0.45f, 0);
        }
        else if(PlayerMoviment2dWithSkeletalSword.move < 0)
        {
            colliderAtkPlayer.offset = new Vector2 (-0.45f, 0);

        }
    }
}
