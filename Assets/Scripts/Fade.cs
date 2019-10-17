using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private Image fade;

    // Start is called before the first frame update
    void Start()
    {
        IEnumerator ie = FadeIn();
        StartCoroutine(ie);
    }

    IEnumerator FadeIn()
    { 
        float fadeAmount = 1f;
        fade.gameObject.SetActive(true);
        while (fadeAmount > 0f)
        {
            fade.color = new Color(0f, 0f, 0f, fadeAmount);
            fadeAmount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        fade.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
