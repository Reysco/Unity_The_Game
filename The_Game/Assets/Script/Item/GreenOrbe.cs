
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrbe : MonoBehaviour
{
    GUIControl gControl;

    private Animator anim;
    public static bool keyOn;


    private void Start()
    {
        gControl = GUIControl.gControl;

        anim = GetComponent<Animator>();

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            {


                gControl.KeyOn();
                keyOn = true;

                Destroy(gameObject);



            }

        }
    }
}

