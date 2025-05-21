using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalChest : MonoBehaviour
{
    public static NormalChest normalchest;

    public Animator anim;
    public GameObject redheart;
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
            if (PlayerMoviment2dWithSkeletalSword.isGrounded == true && Input.GetKeyDown(KeyCode.E))
            {
                anim.enabled = true;
                redheart.SetActive(true);
                Destroy(bc);

            }
        }



    }
}
