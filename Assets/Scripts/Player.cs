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

    public GameObject spellPrefab;
    public GameObject spellParticle;
    GameObject spell;

    public AudioClip[] lazSpellSounds;
    public AudioClip lazJumpSound;
    public AudioClip lazStartSound;
    public AudioClip normalSpellSound;
    public AudioClip normalJumpSound;

    public Camera cam;

    Rigidbody2D rb;
    BoxCollider2D myFeet;
    Animator anim;
    AudioSource myAudioSource;
    
    


    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
        anim.Play("Run");
       
        
        GameEngine.instance.NotifyOnGameStartedObservers += GameStarted;
        if (FindObjectOfType<StartMenuController>().isLazMode)
        {
            myAudioSource.clip = lazStartSound;
            myAudioSource.Play();
        }
    }

    void OnDestroy()
    {
        GameEngine.instance.NotifyOnGameStartedObservers -= GameStarted;
    }


    private void GameStarted()
    {
        transform.position = new Vector2(-5f, transform.position.y);
        
    }


    void FixedUpdate()
    {
            
        if (timer>=1 && timer<=6) 
        { 
            timer += 1 * Time.deltaTime; 
        }

        if(Input.touchCount>0)
        {

        Jump();
        Fire();

        }
    }
    
    
    void Jump()
    {
        Vector3 touchPosition = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("floor"))  || !GameEngine.instance.IsPlaying)
        {
            
            return;
        }
        if (touchPosition.x < cam.transform.position.x )
        
        {
            anim.SetTrigger("isJumping");

            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpSpeed));

            if (FindObjectOfType<StartMenuController>().isLazMode)
            {
                myAudioSource.clip = lazJumpSound;
                myAudioSource.Play();
            }
            else
            {
                myAudioSource.clip = normalJumpSound;
                myAudioSource.Play();
            }
            
        }

    }
    
    void Fire()
    {
        Vector3 touchPosition = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
        if(!GameEngine.instance.IsPlaying)
        {
            return;
        }
        if (touchPosition.x > cam.transform.position.x && timer >= fireTimer )
        
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

        if (FindObjectOfType<StartMenuController>().isLazMode)
        {
            myAudioSource.clip = PlayRandomLazSpellSound();
            myAudioSource.Play();
        }
        else
        {
            myAudioSource.clip = normalSpellSound;
            myAudioSource.Play();
        }
        

    }

    public AudioClip PlayRandomLazSpellSound()
    {
        var i = Random.Range(0, 7);
        AudioClip randomSound = lazSpellSounds[i];
        return randomSound;
    }

    
   


}
