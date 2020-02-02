using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderController : MonoBehaviour
{
    Slider sl;
    public GameObject fill;
    // Start is called before the first frame update
    void Start()
    {
        sl = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        fill.GetComponent<Image>().fillAmount += damage;
        if(fill.GetComponent<Image>().fillAmount >=1)
        {
            StartCoroutine(Restart());
        }
    }
    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
