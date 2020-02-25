using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public GameObject gameEndCanvas;
    
    void Start()
    {
        gameEndCanvas.gameObject.SetActive(false);

    }
        

    public void ShowGameEndCanvas()
    {
        gameEndCanvas.gameObject.SetActive(true);
    }


    public void PlayButtonTapped()
    {
        GameEngine.instance.point = 0;
        SceneManager.LoadScene(1);
        gameEndCanvas.gameObject.SetActive(false);
    }
    public void QuitGameButton()
    {
        Application.Quit();
    }
}
    