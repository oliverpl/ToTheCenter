using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arcBehavior : MonoBehaviour
{
    public PolygonCollider2D ArcCollision { get; set; }

    private void Awake()
    {
        ArcCollision = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
