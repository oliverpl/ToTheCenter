using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private CircleCollider2D playerCollisionBox;
    private object arcCollisionBox;
    private float maxCollisionDrawOffset;
    public float speed = 0.05F;
    public Dictionary<string, KeyCode> movementMap;

    public void Awake()
    {
        playerCollisionBox = GetComponent<CircleCollider2D>();
        maxCollisionDrawOffset = playerCollisionBox.radius - 0.35f;
        arcCollisionBox = FindObjectOfType<arcBehavior>();
    }

    public void Update()
    {
        var playerPosition = transform.position;
        var mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = (mousePosition - (Vector2)playerPosition).normalized;
        var hit = Physics2D.Raycast(playerPosition, direction, Vector2.Distance(mousePosition, playerPosition) + (playerCollisionBox.radius - 0.45f), LayerMask.GetMask("Arc"));
        if (hit.collider != null)
        {
            Debug.Log("Hit point: " + hit.point);
            var drawOffset = new Vector2(direction.x * maxCollisionDrawOffset * -1, direction.y * maxCollisionDrawOffset * -1);
            //Debug.Log("Draw Offset: " + drawOffset);
            transform.position = hit.point + drawOffset;
        }
        else
        {
            //Debug.Log("Miss point: " + mousePosition);
            playerCollisionBox.transform.position = mousePosition;
        }
    }
}
