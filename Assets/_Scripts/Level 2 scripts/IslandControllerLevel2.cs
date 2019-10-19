using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using util;

public class IslandControllerLevel2 : MonoBehaviour
{
    public float horizontalSpeed = 0.04f;

    //Top X 3.53
    //Top Y -3.68
    //Bottom X -5.63
    //Botton Y 2.06


    public BoundaryLevel2 boundary;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    /// <summary>
    /// This method moves the ocean down the screen by verticalSpeed
    /// </summary>
    void Move()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    /// <summary>
    /// This method resets the ocean to the resetPosition
    /// </summary>
    void Reset()
    {
        float randomYPosition = Random.Range((boundary.Bottom), boundary.Top);
        transform.position = new Vector2(boundary.Right, randomYPosition);
    }

    /// <summary>
    /// This method checks if the ocean reaches the lower boundary
    /// and then it Resets it
    /// </summary>
    void CheckBounds()
    {
        if (transform.position.x <= boundary.Left)
        {
            Reset();
        }
    }
}
