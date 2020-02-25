using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bear : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;


    public Canvas gameEndCanvas;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Start()
    {        
        rb.velocity = new Vector2(5f, 0);
        anim.Play("BearRepair");
        StartCoroutine (DestroyBear());
    }
    IEnumerator DestroyBear()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
