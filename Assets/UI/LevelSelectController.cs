using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelectController : MonoBehaviour
{
    // Start is called before the first frame update
    public Image fade;
    public AudioSource sting;
    public AudioSource background;
    public Sprite[] levelScreenshots;
    public string[] levelName;
    public Button playButton;
    public Button prevButton;
    public Button nextButton;
    public Button howToPlayButton;

    public Button gameSettingsButton;
    public Image levelScreenshotHolder; 
    public Text levelText; 
    int current_selection = 1;
    void Start()
    {
      current_selection = 0;
      UpdateSelection();
      playButton.onClick.AddListener(PlayLevel);
      prevButton.onClick.AddListener(Decrement);
      nextButton.onClick.AddListener(Increment);

    }
    void UpdateSelection() {
      Debug.Log(current_selection);

      levelScreenshotHolder.sprite = levelScreenshots[current_selection];
      levelText.text = levelName[current_selection];
    }
    void PlayLevel() {
      Debug.Log("Play level " + current_selection);
      IEnumerator ie = loadLevel();
      StartCoroutine(ie);
    }
    IEnumerator loadLevel() {
      for (var i = background.volume; i >= 0; i-=0.1f) {
        background.volume = i;
        yield return new WaitForSeconds(0.01f); 
      }
      background.Stop();
      sting.volume = 0f;
      sting.Play(0);
      for (var i = 0f; i < 1f; i+=0.05f) {
        sting.volume = i;
        yield return new WaitForSeconds(0.01f); 
      }
      yield return new WaitForSeconds(1); 
      float fadeAmount = 0f;
      fade.gameObject.SetActive(true);
      while (fadeAmount <= 1)  {
        fade.color = new Color(0f,0f,0f,fadeAmount);
        fadeAmount += 0.05f;
        Debug.Log(fadeAmount);
        yield return new WaitForSeconds(0.01f); 
      }
      fade.color = new Color(0f,0f,0f,1f);

      while (sting.isPlaying)
      {
          yield return null;
      }
        SceneManager.LoadScene("Scenes/"+levelName[current_selection]);
    }
    void Decrement() {
      current_selection = Mathf.Abs(current_selection - 1) % levelScreenshots.Length;  
      UpdateSelection();
    }
    void Increment() {
      current_selection = (current_selection + 1) % levelScreenshots.Length;  
      UpdateSelection();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
