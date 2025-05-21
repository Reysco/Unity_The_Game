using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("CoinColector"))
        {
            ScoreTextGoldenCoin.GoldencoinAmount += 10;
            Destroy(gameObject);
        }

    }
}
