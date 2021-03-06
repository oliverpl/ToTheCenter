﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IObserverable {
    private CircleCollider2D playerCollisionBox;
    private float maxCollisionDrawOffset;
    private Vector2 arcCenter;

    public float speed = 0.05F;
    public Observer Observer { get; set; }

    public void Awake()
    {
        playerCollisionBox = GetComponent<CircleCollider2D>();
        maxCollisionDrawOffset = playerCollisionBox.radius - 0.35f;
        arcCenter = GameObject.FindWithTag("FirstArc").GetComponent<PolygonCollider2D>().transform.position;
        Observer = GameObject.FindWithTag("Observer").GetComponent<Observer>();
    }

    public void Update()
    {
        var playerPosition = transform.position;
        if (Observer.GameOver)
        {
            Debug.Log("Winner!");
        }
        else if(CheckWinCondition(playerPosition))
        {
            Debug.Log("Winner!");
            Observer.GameOver = true;
        }
        else
        {
            this.UpdatePlayer(playerPosition);
        }
    }

    private void UpdatePlayer(Vector2 playerPosition)
    {
        var mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = (mousePosition - (Vector2)playerPosition).normalized;
        var hit = Physics2D.Raycast(playerPosition, direction, Vector2.Distance(mousePosition, playerPosition) + (playerCollisionBox.radius - 0.45f), LayerMask.GetMask("Arc"));
        if (hit.collider != null)
        {
            Debug.Log("Loser!");
            //Debug.Log("Hit point: " + hit.point);
            var drawOffset = new Vector2(direction.x * maxCollisionDrawOffset * -1, direction.y * maxCollisionDrawOffset * -1);
            //Debug.Log("Draw Offset: " + drawOffset);
            transform.position = hit.point + drawOffset;
        }
        else
        {
            //Debug.Log("Miss point: " + mousePosition);
            Debug.Log("Current position: " + mousePosition);
            playerCollisionBox.transform.position = mousePosition;
        }
    }

    private bool CheckWinCondition(Vector2 playerPosition)
    {
        var distanceToCenter = Vector2.Distance(playerPosition, arcCenter);
        return distanceToCenter < 2;
    }
}
