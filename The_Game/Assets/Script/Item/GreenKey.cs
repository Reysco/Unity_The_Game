using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenKey : MonoBehaviour
{
    GUIControl gControl;
    GreenChest greenchest;

    public static bool GreenKeyOn;


    private void Start()
    {
        gControl = GUIControl.gControl;
        greenchest = GreenChest.greenchest;

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            {


                gControl.GreenKeyON();
                GreenKeyOn = true;

                Destroy(gameObject);


            }

        }
    }
}