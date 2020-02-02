using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public Canvas gameEndCanvas;

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
        SceneManager.LoadScene(0);
    }
}
    