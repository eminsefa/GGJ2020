using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBroken : MonoBehaviour
{
    
    void OnTriggerExit2D(Collider2D collision)
    {

        if(collision.tag=="Spell")
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == "bear")
        {
            GameEngine.instance.StartGame();
        }
        if(collision.tag=="Player")
        {
            FindObjectOfType<Player>().GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
