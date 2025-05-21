using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHearthChest : MonoBehaviour
{
    GUIControl gControl;

    private Animator anim;


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

            }

        }
    }
}
