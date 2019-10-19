using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

/* Name: Andrew Trinidad
 * Student ID: 301021154
 * Modified last: This code was taken from the original CloudController
 * but this script is for level 2 modifing speed values and directions for the clouds
 */
public class CloudControllerLevel2 : MonoBehaviour
{
    //-0.01
    //0.01

    //0.05
    //0.08
    [Header("Speed Values")]
    [SerializeField]
    public SpeedLevel2 horizontalSpeedRange;

    [SerializeField]
    public SpeedLevel2 verticalSpeedRange;

    public float verticalSpeed;
    public float horizontalSpeed;

    [SerializeField]
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
        Vector2 newPosition = new Vector2(horizontalSpeed, verticalSpeed);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    /// <summary>
    /// This method resets the ocean to the resetPosition
    /// </summary>
    void Reset()
    {
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
        verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);

        float randomYPosition = Random.Range((boundary.Bottom), boundary.Top);
        //transform.position = new Vector2(randomXPosition, Random.Range(boundary.Top, boundary.Top + 2.0f));
        transform.position = new Vector2(Random.Range(boundary.Right, boundary.Right + 2.0f), randomYPosition);
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
