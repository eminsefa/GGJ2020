using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndCreate : MonoBehaviour
{
    public GameObject[] tands;
    GameObject farthest = null;

    private BoxCollider2D bc;
    float horizontalLength;

    public Camera cam;

    float maxX = -Mathf.Infinity;
    public float damage = 0.5f;


    void Start()
    {
        bc = tands[0].GetComponent<BoxCollider2D>();
        horizontalLength = bc.size.x;
    }

    
    public GameObject RandomSpawner()
    {
        int i = Random.Range(0, 4);
        return tands[i];
    }


    public float RandomRange()
    {
        maxX = -Mathf.Infinity;
        farthest = null;
        foreach (FindTree tns in FindObjectsOfType<FindTree>())
        {
            float x = tns.transform.position.x;
            if (x > maxX)
            {
                maxX = x;
                farthest = tns.gameObject;


            }
        }
        float randomRange = Random.Range(0, horizontalLength / 4);
        float range = randomRange + horizontalLength + farthest.transform.position.x;
        
        return range;

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag=="Broken")
        {
            FindObjectOfType<SliderController>().TakeDamage(damage);
        }

        Destroy(collision.gameObject);

        var pos = new Vector2(RandomRange(), 0);
        // GameObject treesAndStones = Instantiate(RandomSpawner(), pos, Quaternion.identity);

        var go = Instantiate(RandomSpawner());
        go.transform.position = pos;

        print("<color=olive>" + go.name + "</color>");

    }

}
