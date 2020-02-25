using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorsController : MonoBehaviour
{
    private BoxCollider2D myCollider;
    private float horizontalLength;
    public Camera mainCamera;
    

    public GameObject[] ground;

    // Start is called before the first frame update
    void Start()
    {
        
        myCollider = ground[0].GetComponent<BoxCollider2D>();
        horizontalLength = myCollider.size.x;

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
