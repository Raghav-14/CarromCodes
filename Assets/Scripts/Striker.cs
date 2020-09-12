using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Striker : MonoBehaviour
{
    Rigidbody2D rigidbodyStriker;
    public LineRenderer visualizerLine;
    Vector2 startPosition;

    Vector2 direction;
    Vector3 worldMousePos;

    Transform selfTransform;
    public int strikerSpeed = 500;
    bool hasStriked = false;
    public bool positionIsSet = false;

    void Awake()
    {
        rigidbodyStriker = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        selfTransform = transform;
    }

    void Update()
    {
        worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();

        if (!hasStriked && !positionIsSet)
        {
            selfTransform.position = new Vector2(Mathf.Clamp(worldMousePos.x, -2.16f, 2.08f), startPosition.y);
        }

        if (positionIsSet && rigidbodyStriker.velocity.magnitude == 0)
        {
            visualizerLine.SetPosition(0, selfTransform.position);
            visualizerLine.SetPosition(1, worldMousePos);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!positionIsSet)
            {
                positionIsSet = true;
            }
        }
    }

    public void StrikerReset()
    {
        rigidbodyStriker.velocity = Vector2.zero;
        hasStriked = false;
        positionIsSet = false;
    }

    public void ShootStriker()
    {
        rigidbodyStriker.AddForce(-direction * CoinCollection.Instance.CalculateStrikerForce());
        hasStriked = true;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0) && rigidbodyStriker.velocity.magnitude == 0)
        {
            ShootStriker();
        }

        if (rigidbodyStriker.velocity.magnitude < 0.3f && rigidbodyStriker.velocity.magnitude != 0)
        {
            StrikerReset();
        }
    }
}
