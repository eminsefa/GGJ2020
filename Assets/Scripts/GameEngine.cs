using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    public static GameEngine instance;

    public delegate void OnGameStarted();
    public event OnGameStarted NotifyOnGameStartedObservers;

    public int point ;



    public bool IsPlaying { get; set; }
    
    
    void Start()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {

            Destroy(this);
        }
        
    }
    
        

    public void StartGame()
    {
        IsPlaying = true;
        FindObjectOfType<ScrollingObject>().ScrollObjects();
        NotifyOnGameStartedObservers?.Invoke();
    }


     public void GameOver()
     {
        IsPlaying = false;
        GetComponent<UiController>().ShowGameEndCanvas();
        FindObjectOfType<Player>().GetComponent<Animator>().SetTrigger("stopMoving");
        
    }

    public void GetPoint()
    {
        point += 100;
        FindObjectOfType<SliderController>().showScore();
    }

   

}
