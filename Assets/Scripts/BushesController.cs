using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushesController : MonoBehaviour
{
    public GameObject[] bushes;
    GameObject farthest = null;

    private BoxCollider2D bc;
    float horizontalLength;

    public Camera cam;

    float maxX = -Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        bc = bushes[0].GetComponent<BoxCollider2D>();
        horizontalLength = bc.size.x;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public GameObject RandomSpawner()
    {
        GameObject bush = null;
        var number = Random.Range(0, 100);
        if(number<20)
        {
            bush = bushes[2];
        }
        else if(number<60)
        {
            bush = bushes[1];
        }
        else if(number<100)
        {
            bush = bushes[0];
        }
        return bush;

    }
    public float RandomRange()
    {
        maxX = -Mathf.Infinity;
        farthest = null;
        foreach (FindBushes bsh in FindObjectsOfType<FindBushes>())
        {
            float x = bsh.transform.position.x;
            if (x > maxX)
            {
                maxX = x;
                farthest = bsh.gameObject;


            }
        }
        float randomRange = Random.Range(horizontalLength/2, horizontalLength);
        float range = randomRange + cam.transform.position.x*2+horizontalLength + farthest.transform.position.x;

        return range;

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        var pos = new Vector2(RandomRange(), 0);
        GameObject treesAndStones = Instantiate(RandomSpawner(), pos, Quaternion.identity);
    }

}
