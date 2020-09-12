using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerIndicator : MonoBehaviour
{
    private static PowerIndicator _instance;
    public static PowerIndicator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PowerIndicator>();
            }
            return _instance;
        }
    }

    public Image powerIndicator;
    public float devideFactor;

    private void Update()
    {
        if(CoinCollection.Instance.striker.GetComponent<Rigidbody2D>().velocity.magnitude==0
            && CoinCollection.Instance.striker.positionIsSet)
        {
            powerIndicator.fillAmount = Vector2.Distance(CoinCollection.Instance.striker.gameObject.transform.position,
                Camera.main.ScreenToWorldPoint(Input.mousePosition)) / devideFactor;
        }
    }
}
