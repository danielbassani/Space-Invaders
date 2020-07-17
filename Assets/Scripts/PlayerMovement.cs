using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalMove = 0f;
    public Transform transform;
    public float speed = 0.001f;
    public Joystick joystick;
    private Vector3 position;

    private void FixedUpdate()
    {
        if (joystick.Horizontal >= 0.05f)
        {
            horizontalMove = speed;
        }
        else if (joystick.Horizontal <= -0.05f)
        {
            horizontalMove = -speed;
        }
        else
        {
            horizontalMove = 0f;
        }
        position = new Vector3(horizontalMove, 0, 0);
        transform.position = transform.position + position;
    }
}
