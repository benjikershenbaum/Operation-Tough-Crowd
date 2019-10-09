using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button replayButton;
    [SerializeField] private Image fade;
    private bool paused = false;
    private string nextScene;
    void Start()
    {
        menuButton.onClick.AddListener(menuButtonClick);
        replayButton.onClick.AddListener(replayButtonClick);
    }

    private void menuButtonClick()
    {
        nextScene = "Menu";
        IEnumerator ie = FadeOut();
        StartCoroutine(ie);
    }

    private void replayButtonClick()
    {
        nextScene = SceneManager.GetActiveScene().name;
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

        SceneManager.LoadScene(nextScene);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
          paused = !paused;
          pauseMenu.SetActive(paused);
        }
    }
}
