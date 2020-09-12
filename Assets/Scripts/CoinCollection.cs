using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private static CoinCollection _instance;
   public static CoinCollection Instance
    {
        get
        {
            if(_instance==null)
            {
                _instance = GameObject.FindObjectOfType<CoinCollection>();
            }
            return _instance;
        }
    }

    //varibales
    public Transform coinCollectedPosition;
    public Striker striker;
    public float coinOffset = 0.35f;
    public int numberOfCoinCollected;
    public float baseStrikerForce;
    float strikerForce;

    public void CoinCollected(GameObject collectedCoin)
    {
        collectedCoin.GetComponent<CircleCollider2D>().isTrigger = true;
        collectedCoin.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        coinOffset = 0.35f * numberOfCoinCollected;
        collectedCoin.transform.position = new Vector2(coinCollectedPosition.position.x + coinOffset, coinCollectedPosition.position.y);
        numberOfCoinCollected += 1;
    }

    public float CalculateStrikerForce()
    {
        strikerForce=baseStrikerForce*PowerIndicator.Instance.powerIndicator.fillAmount;
        return strikerForce;
    }
}
