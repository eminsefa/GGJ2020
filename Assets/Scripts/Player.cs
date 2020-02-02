using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed=5f;
    public float jumpSpeed = 50f;
    public float fireTimer = 5f;
    public float spellFireSpeed = 15f;
    public float timer = 1;

    Rigidbody2D rb;
    BoxCollider2D myFeet;
    Animator anim;

    
    public GameObject spellPrefab;
    public GameObject spellParticle;
    GameObject spell;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("Run");
        rb = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();

        GameEngine.instance.NotifyOnGameStartedObservers += GameStarted;
    }

    void OnDestroy()
    {
        GameEngine.instance.NotifyOnGameStartedObservers -= GameStarted;
    }


    private void GameStarted()
    {
        transform.position = new Vector3(-4.45F, transform.position.y);

        //var force = new Vector3(20f, 10f, 0f);
        //rb.AddForce(force);
    }


    void FixedUpdate()
    {
            
        if (timer>=1 && timer<=6) 
        { 
            timer += 1 * Time.deltaTime; 
        }            
            
        Jump();
        Fire();
    }
    
    
    void Jump()
    {
        if(!myFeet.IsTouchingLayers(LayerMask.GetMask("floor")))
        {
            
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetTrigger("isJumping");
            
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpSpeed));
        }

    }
    
    void Fire()
    {
        if (Input.GetButtonDown("Fire1") && timer >= fireTimer)
        {

            anim.SetTrigger("isFiring");
            timer = 1;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        GameEngine.instance.GameOver();
    }
    public void isFired()
    {
        spell=Instantiate(spellPrefab, transform.position + new Vector3(3f, 0), Quaternion.identity) ;
        GameObject spellP =Instantiate(spellParticle, transform.position + new Vector3(3f, 0), Quaternion.identity);
        Destroy(spellP, 3f);
        spell.GetComponent<Rigidbody2D>().velocity = new Vector2(spellFireSpeed, 0);
            
        
        


    }
    
   


}
