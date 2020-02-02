using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public static GameEngine instance;

    public delegate void OnGameStarted();
    public event OnGameStarted NotifyOnGameStartedObservers;

    public GameObject player;
    public UiController uiController;

    public bool IsPlaying { get; private set; }


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
        NotifyOnGameStartedObservers?.Invoke(); 
    }


     public void GameOver()
     {
        IsPlaying = false;
        uiController.ShowGameEndCanvas();   
     }


}
