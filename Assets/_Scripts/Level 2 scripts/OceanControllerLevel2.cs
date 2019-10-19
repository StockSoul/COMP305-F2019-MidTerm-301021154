using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: Andrew Trinidad
 * Student ID: 301021154
 * Modified last: This code was taken from the original OceanController
 * but this script is for level 2 modifing speed values and directions of the Ocean.
 */
public class OceanControllerLevel2 : MonoBehaviour
{
    public float horizontalSpeed = 0.1f;
    public float resetPosition = 4.8f;
    public float resetPoint = -4.8f;

    //10.4
    //-18.4

    // Start is called before the first frame update
    void Start()
    {
        //Reset();
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
        transform.position = new Vector2(resetPosition, -0.8f);
    }

    /// <summary>
    /// This method checks if the ocean reaches the lower boundary
    /// and then it Resets it
    /// </summary>
    void CheckBounds()
    {
        if (transform.position.x <= resetPoint)
        {
            Reset();
        }
    }
}
