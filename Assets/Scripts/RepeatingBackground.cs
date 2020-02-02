﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D collider;
    private float horizontalLength;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        horizontalLength = collider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -horizontalLength)
        {
            RepositionBackground();

        }
    }
    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(horizontalLength, 0);
        transform.position = (Vector2)transform.position + groundOffset*2f + new Vector2(-0.23f,0);
    }
}
