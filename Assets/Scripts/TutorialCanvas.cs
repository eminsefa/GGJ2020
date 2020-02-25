using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanvas : MonoBehaviour
{
    public GameObject jumpText, extunguishText, repairText, thatsAllText;

    void Start()
    {
        StartCoroutine(ShowTutorialCanvas());
    }

    IEnumerator ShowTutorialCanvas()
    {
        yield return new WaitForSeconds(3.5f);
        extunguishText.SetActive(true);

        yield return new WaitForSeconds(2f);
        extunguishText.SetActive(false);
        jumpText.SetActive(true);

        yield return new WaitForSeconds(2f);
        jumpText.SetActive(false);
        repairText.SetActive(true);

        yield return new WaitForSeconds(2f);
        repairText.SetActive(false);
        thatsAllText.SetActive(true);

        yield return new WaitForSeconds(2f);
        thatsAllText.SetActive(false);

    }
}
