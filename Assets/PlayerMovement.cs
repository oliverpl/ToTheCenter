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
        movementMap = new Dictionary<string, KeyCode>
        {
            {"up", KeyCode.W },
            {"down", KeyCode.D },
            {"left", KeyCode.L },
            {"right", KeyCode.R }
        };
    }

    public void Update()
    {
        var mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = (mousePosition - (Vector2)transform.position).normalized;
        var hit = Physics2D.CircleCast(transform.position, playerCollisionBox.radius-0.5f, direction, Vector2.Distance(mousePosition, transform.position), LayerMask.GetMask("Arc"));
        //Debug.Log("Start point: " + transform.position);
        if (hit.collider != null)
        {
            //Debug.Log("Hit point: " + hit.point);
            //playerCollisionBox.transform.Translate(hit.point);
            var lineHit = Physics2D.Linecast(hit.collider.transform.position, mousePosition);
            if (lineHit.collider == null)
            {

            }
            var drawOffset = new Vector2(direction.x * maxCollisionDrawOffset, direction.y * maxCollisionDrawOffset);
            Debug.Log("Draw Offset: " + drawOffset);
            transform.position = hit.point + drawOffset;
        }
        else
        {
            //Debug.Log("Miss point: " + mousePosition);
            //playerCollisionBox.transform.Translate(mousePosition);
            playerCollisionBox.transform.position = mousePosition;
        }
    }

    private string MovementDirection()
    {
        foreach (var key in movementMap.Keys)
        {
            if (Input.GetKeyDown(movementMap[key]))
            {
                return key;
            }
        }

        return string.Empty;
    }
}
