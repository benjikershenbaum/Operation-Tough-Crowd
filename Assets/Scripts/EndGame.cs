﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private Button replayButton;
    [SerializeField] private Image fade;
    // Start is called before the first frame update
    void Start()
    {
        menuButton.onClick.AddListener(menuButtonClick);
        replayButton.onClick.AddListener(replayButtonClick);
    }

    private void menuButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }

    private void replayButtonClick()
    {
        IEnumerator ie = FadeOut();
        StartCoroutine(ie);
    }

    IEnumerator FadeOut()
    {
        fade.gameObject.SetActive(true);
        float fadeAmount = 0f;
        fade.gameObject.SetActive(true);
        while (fadeAmount < 1f)
        {
            fade.color = new Color(0f, 0f, 0f, fadeAmount);
            fadeAmount += 0.01f;
            Debug.Log(fadeAmount);
            yield return new WaitForSeconds(0.01f);
        }

        SceneManager.LoadScene("Sqaure");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
