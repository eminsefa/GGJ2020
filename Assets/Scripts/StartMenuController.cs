using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public GameObject lazModeSprite, normalModeSprite;
    public bool isLazMode = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LazModeButton()
    {
        normalModeSprite.SetActive(false);
        lazModeSprite.SetActive(true);
        isLazMode = true;
    }

    public void NormalModeButton()
    {
        lazModeSprite.SetActive(false);
        normalModeSprite.SetActive(true);
        isLazMode = false;
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }

    

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
