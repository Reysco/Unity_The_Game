using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDoor : MonoBehaviour
{

    private Animator anim;
    public static bool enteringDoor;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (GreenOrbe.keyOn && PlayerMoviment2dWithSkeletalSword.isGrounded == true && Input.GetKeyDown(KeyCode.E))
            {

                    //  anim.enabled = true;
                    // enteringDoor = true;

                    Destroy(gameObject);
                
            }

        }
    }
}
