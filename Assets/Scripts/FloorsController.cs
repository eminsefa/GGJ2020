using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorsController : MonoBehaviour
{
    private BoxCollider2D collider;
    private float horizontalLength;
    public Camera mainCamera;
    private Rigidbody2D rb2d;
    public float scrollSpeed = 5f;

    public GameObject[] ground;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
        collider = ground[0].GetComponent<BoxCollider2D>();
        horizontalLength = collider.size.x;

        GameEngine.instance.NotifyOnGameStartedObservers += ScrollObjects;
    }

    void OnDestroy()
    {
        GameEngine.instance.NotifyOnGameStartedObservers -= ScrollObjects;
    }


    private void ScrollObjects()
    {
        rb2d.velocity = new Vector2(scrollSpeed, 0);

    }

    
    void Update()
    {
        if (IsGroundOutOfSight())
        {
            GenerateNextGround();

        }

    }
    private bool IsGroundOutOfSight()
    {
        return transform.position.x <-horizontalLength;
        
        
    }

    private void GenerateNextGround()
    {
        Vector2 groundOffset = new Vector2(horizontalLength, 0);
        ChangeVisibleChild();
        var targetPosition = (Vector2)transform.position + groundOffset * 2f ;
        transform.position = targetPosition;
        

    }


    private void ChangeVisibleChild()
    {
        var number = Random.Range(0, 100);

        if (number < 50)
        {
            ground[0].SetActive(true);
            ground[1].SetActive(false);
        }
        else
        {
            ground[0].SetActive(false);
            ground[1].SetActive(true); 
        }
    }

}
