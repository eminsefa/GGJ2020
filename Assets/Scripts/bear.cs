using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bear : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Start()
    {        
        rb.velocity = new Vector2(5f, 0);
        anim.Play("BearWalking");
        StartCoroutine (EndGame());
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(40f);
        rb.velocity = new Vector2(-10f,0);
        transform.rotation = Quaternion.Euler(new Vector3(0, 180f, 0));


        anim.Play("Idle");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Spell")
        {
        GameEngine.instance.GameOver();
        anim.Play("BearRepair");
            Destroy(collision.gameObject);
        }
    }
}
