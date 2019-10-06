using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public Button LevelSelectButton;
    public Button HowToPlayButton;
    public Button GameSettingsButton; 
    public GameObject LevelSelect;
    public GameObject HowToPlay;
    public GameObject GameSettings;
    public GameObject previousScreen;
    public Image previousButton;
    private Color selected = Color.white;
    public Color unselected;

    private Image LevelSelectImage;
    private Image HowToPlayImage;
    private Image GameSettingsImage;


    void ChangeLevelSelect() {
      previousScreen.SetActive(false);
      previousButton.color = unselected;

      previousScreen = LevelSelect;
      previousButton = LevelSelectImage;
      
      LevelSelect.SetActive(true);
      LevelSelectImage.color = selected;
      audioSource.pitch = Random.Range(0.9f, 1f);
      audioSource.Play(0);
    }
    void ChangeHowToPlay() {
      previousScreen.SetActive(false);
      previousButton.color = unselected;

      previousScreen = HowToPlay;
      previousButton = HowToPlayImage;
      HowToPlay.SetActive(true);
      HowToPlayImage.color = selected;
      audioSource.pitch = Random.Range(0.9f, 1f);
      audioSource.Play(0);

    }
    void ChangeGameSettings() {
      
      previousScreen.SetActive(false);
      previousButton.color = unselected;

      previousScreen = GameSettings;
      previousButton = GameSettingsImage;
      GameSettings.SetActive(true);
      GameSettingsImage.color = selected;
      audioSource.pitch = Random.Range(0.9f, 1f);

      audioSource.Play(0);
    }
    void Start()
    {
      LevelSelectButton.onClick.AddListener(ChangeLevelSelect);
      LevelSelectImage = LevelSelectButton.GetComponent<Image>();
      previousScreen = LevelSelect;
      previousButton = LevelSelectImage;
      LevelSelectImage.color = selected;

      HowToPlayButton.onClick.AddListener(ChangeHowToPlay);
      HowToPlayImage = HowToPlayButton.GetComponent<Image>();
      HowToPlayImage.color = unselected;

      GameSettingsButton.onClick.AddListener(ChangeGameSettings);
      GameSettingsImage = GameSettingsButton.GetComponent<Image>();
      GameSettingsImage.color = unselected;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
