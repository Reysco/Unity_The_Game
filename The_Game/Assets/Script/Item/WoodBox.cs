using Packages.Rider.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class WoodBox : MonoBehaviour
{
    [SerializeField] private int lifewoodbox = 3;

    public SpriteRenderer Woodbox;
    public Sprite[] WoodBoxImages = new Sprite[3];

    void Start()
    {
        Woodbox = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        switch (lifewoodbox)
        {
            case 3:
                Woodbox.sprite = WoodBoxImages[2];
                break;

            case 2:
                Woodbox.sprite = WoodBoxImages[1];
                break;

            case 1:
                Woodbox.sprite = WoodBoxImages[0];
                break;

            case 0:
                GetComponent<Animator>().enabled = true;
                Destroy(GetComponent<Animator>(), 1);

              //  Destroy(GetComponent<BoxCollider2D>());
               Destroy(GetComponent<WoodBox>());


                Destroy(gameObject, 0.5f);


                break;
                
        }

        
    }
    private void OnTriggerEnter2D(Collider2D Coll)
    {
        if(Coll.gameObject.tag == "Attack")
        {
            lifewoodbox--;
        }
    }
}
