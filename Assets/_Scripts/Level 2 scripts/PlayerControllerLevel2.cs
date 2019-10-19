using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

/* Name: Andrew Trinidad
 * Student ID: 301021154
 * Modified last: This code was taken from the original PlayerController
 * but this script is for level 2 modifing movement axis's.
 */
public class PlayerControllerLevel2 : MonoBehaviour
{
    public SpeedLevel2 speed;
    public BoundaryLevel2 boundary;

    public GameController gameController;

    // private instance variables
    private AudioSource _thunderSound;
    private AudioSource _yaySound;

    // Start is called before the first frame update
    void Start()
    {
        _thunderSound = gameController.audioSources[(int)SoundClip.THUNDER];
        _yaySound = gameController.audioSources[(int)SoundClip.YAY];
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    public void Move()
    {
        Vector2 newPosition = transform.position;

        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            //newPosition += new Vector2(speed.max, 0.0f);
            newPosition += new Vector2(0.0f, speed.min);
        }

        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            //newPosition += new Vector2(speed.min, 0.0f);
            newPosition += new Vector2(0.0f, speed.max);
        }

        transform.position = newPosition;
    }

    public void CheckBounds()
    {
        // check right boundary
        if (transform.position.y > boundary.Top)
        {
            //transform.position = new Vector2(boundary.Right, transform.position.y);
            transform.position = new Vector2(transform.position.x, boundary.Top);
        }

        // check left boundary
        if (transform.position.y < boundary.Bottom)
        {
            //transform.position = new Vector2(boundary.Left, transform.position.y);
            transform.position = new Vector2(transform.position.x, boundary.Bottom);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Cloud":
                Debug.Log("Collided with cloud");
                _thunderSound.Play();
                gameController.Lives -= 1;
                break;
            case "Island":
                Debug.Log("Collided with Island");
                _yaySound.Play();
                gameController.Score += 100;
                break;
        }
    }
}
