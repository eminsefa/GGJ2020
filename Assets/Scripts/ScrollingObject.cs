using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float scrollSpeed = 5f;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GameEngine.instance.NotifyOnGameStartedObservers += ScrollObjects;

        if (GameEngine.instance.IsPlaying)
        {
            ScrollObjects();
        }
    }


    void OnDestroy()
    {
        GameEngine.instance.NotifyOnGameStartedObservers -= ScrollObjects;
    }


    void ScrollObjects()
    {
        rb2d.velocity = new Vector2(scrollSpeed, 0);
    }
}
   