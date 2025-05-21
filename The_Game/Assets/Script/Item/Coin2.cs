using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2 : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("CoinColector2"))
        {
            ScoreTextAmethystCoin.AmethystcoinAmount += 10;
            Destroy(gameObject);
        }

    }
}
