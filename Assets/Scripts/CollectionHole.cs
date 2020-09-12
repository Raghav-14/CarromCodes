using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionHole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            CoinCollection.Instance.CoinCollected(collision.gameObject);
        }

        if (collision.gameObject.tag == "Striker")
        {
            collision.GetComponent<Striker>().StrikerReset();
        }
    }
}
