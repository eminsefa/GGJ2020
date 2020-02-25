using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHit : MonoBehaviour
{
    public Sprite repaired;
    public GameObject parent;

    int repairSpriteNumber = 10;
    public GameObject[] repairSprites;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
     void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Spell")
        {
            SpawnRepairSprites();
            GameEngine.instance.GetPoint();
            Destroy(collision.gameObject);
            

        }
        if(collision.tag=="RepairSprites")
        {
            parent.GetComponent<SpriteRenderer>().sprite = repaired;
            
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
    }

    void SpawnRepairSprites()
    {
        
        for(int i=0; i<repairSpriteNumber; i++)
        {
            var r = Random.Range(0, 2);
            var randomXPos = Random.Range(-5, 4);
            var randomYPos = Random.Range(1, 5);
            Vector2 spawnPos = new Vector2(transform.position.x+randomXPos, transform.position.y + 4f+3/randomYPos);

            GameObject repairSprite = Instantiate(repairSprites[r], spawnPos, Quaternion.identity);

            float repairSpriteSpeed = parent.gameObject.GetComponent<Rigidbody2D>().velocity.x;
            repairSprite.GetComponent<Rigidbody2D>().velocity = new Vector2(repairSpriteSpeed,0);
            Destroy(repairSprite, 0.5f);

        }
        

    }
}
