using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //private CircleCollider2D playerCollisionBox;
    private object arcCollisionBox;
    public float speed = 0.05F;
    public Dictionary<string, KeyCode> movementMap;

    public void Awake()
    {
        //playerCollisionBox = GetComponent<CircleCollider2D>();
        arcCollisionBox = GetComponent<arcBehavior>();
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
        var playerCollisionBox = GetComponent<CircleCollider2D>();
        var mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = (mousePosition - playerCollisionBox.offset.normalized).normalized;
        //var hit = Physics2D.Linecast(playerCollisionBox.offset.normalized, mousePosition, LayerMask.GetMask("Arc"));
        var hit = Physics2D.CircleCast(playerCollisionBox.offset, playerCollisionBox.radius-0.5f, direction, Vector2.Distance(mousePosition, playerCollisionBox.offset),LayerMask.GetMask("Arc"));
        if (hit.collider != null)
        {
            Debug.Log("Hit point: " + hit.point);
            //playerCollisionBox.transform.Translate(hit.point);
            playerCollisionBox.transform.position = new Vector2(hit.point.x+playerCollisionBox.radius-0.35f, hit.point.y);
        }
        else
        {
            Debug.Log("Miss point: " + mousePosition);
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
