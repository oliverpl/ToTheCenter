using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arcBehavior : MonoBehaviour
{
    public PolygonCollider2D ArcCollision { get; set; }
    private const float defaultRotationSpeed = 0.3f;

    private void Awake()
    {
        ArcCollision = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(0f, 0f, defaultRotationSpeed);
	}
}
