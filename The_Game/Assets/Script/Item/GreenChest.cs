using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenChest : MonoBehaviour
{ 
    public static GreenChest greenchest;

    public Animator anim;
    public GameObject key;
    public BoxCollider2D bc;

   



    void Start()
    {
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //PlayerMoviment2dWithSkeletalSword.move.ShowImageChest(true);
            if (GreenKey.GreenKeyOn && PlayerMoviment2dWithSkeletalSword.isGrounded == true && Input.GetKeyDown(KeyCode.E))
            {
                anim.enabled = true;
                key.SetActive(true);
                Destroy(bc);
             
            }
        }



    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerMoviment2dWithSkeletalSword.move.ShowImageChest(false);
        }
    }*/


}
