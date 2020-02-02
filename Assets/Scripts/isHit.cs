using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHit : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite repaired;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Spell")
        {
            parent.GetComponent<SpriteRenderer>().sprite = repaired;
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
        
    }

}
