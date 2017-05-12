using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D playerCollisionBox;
    public float speed = 0.05F;

    public void Awake()
    {
        playerCollisionBox = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed);
    }
}
