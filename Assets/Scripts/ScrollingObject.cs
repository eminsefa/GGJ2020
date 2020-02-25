using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float scrollSpeed;
    public float difficultyTimer;
    float difficultySpeed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GameEngine.instance.NotifyOnGameStartedObservers += ScrollObjects;

        
        
    }
    void Update()
    {
        if (GameEngine.instance.IsPlaying)
        {
            ScrollObjects();
        }
        difficultyTimer += Time.deltaTime/5;
        difficultySpeed = scrollSpeed - difficultyTimer ;
        if (!GameEngine.instance.IsPlaying)
            StopScroll();
    }

    void OnDestroy()
    {
        GameEngine.instance.NotifyOnGameStartedObservers -= ScrollObjects;
    }


    public void ScrollObjects()
    {
        rb2d.velocity = new Vector2(difficultySpeed, 0);
    }
    public void StopScroll()
    {
        rb2d.velocity = Vector2.zero;
    }
}
   