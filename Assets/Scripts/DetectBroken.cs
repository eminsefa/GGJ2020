using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBroken : MonoBehaviour
{
    
    void OnTriggerExit2D(Collider2D collision)
    {
        print("<color=green>" + collision.gameObject.name + "</color>");

        if(collision.tag=="Spell")
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == "bear")
        {
            GameEngine.instance.StartGame();
        }
    }
}
