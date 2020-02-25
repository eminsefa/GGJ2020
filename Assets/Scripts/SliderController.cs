using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    Slider sl;
    public GameObject fill;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = GameEngine.instance.point.ToString();
        sl = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameEngine.instance.point.ToString();
    }
    public void TakeDamage(float damage)
    {
        fill.GetComponent<Image>().fillAmount -= damage;
        if(fill.GetComponent<Image>().fillAmount <=0)
        {
            GameEngine.instance.GameOver();
        }
    }
    public void showScore()
    {
        scoreText.text = GameEngine.instance.point.ToString();
    }
}
