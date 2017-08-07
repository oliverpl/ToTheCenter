using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcBehavior : MonoBehaviour, IObserverable
{
    private const float defaultRotationSpeed = 0.3f;

    public Observer Observer { get; set; }

    private void Awake()
    {
        Observer = GameObject.FindWithTag("Observer").GetComponent<Observer>();
    }

    // Update is called once per frame
    void Update () {
        if (!Observer.GameOver)
        {
            transform.Rotate(0f, 0f, defaultRotationSpeed);
        }
	}
}
