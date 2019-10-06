using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDifficulty : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource click;
    public Button easyButton;
    public Text easyText;
    public Button mediumButton;
    public Text mediumText;

    public Button hardButton;
    public Text hardText;


    public Button extremeButton;
    public Text extremeText;

    public Color selectedColor;
    public Color unselectedColor; 
    private Text previous;
     void Start()
    {
        easyButton.onClick.AddListener(SetEasy);
        easyText.color = unselectedColor;
        previous = easyText;
        mediumButton.onClick.AddListener(SetMedium);
        mediumText.color = unselectedColor;
        hardButton.onClick.AddListener(SetHard);
        hardText.color = unselectedColor;
        extremeButton.onClick.AddListener(SetExtreme);
        extremeText.color = unselectedColor;
        SetMedium();
    }
    void SetEasy() {
      click.Play(0);
      previous.color = unselectedColor;
      easyText.color = selectedColor;
      previous = easyText;
      Difficulty.level = 0;
    }
    void SetMedium() {
      click.Play(0);

      previous.color = unselectedColor;
      mediumText.color = selectedColor;
      previous = mediumText;
      Difficulty.level = 1;
    }
    void SetHard() {
      click.Play(0);

      previous.color = unselectedColor;
      hardText.color = selectedColor;
      previous = hardText;
      Difficulty.level = 2;
    }
    void SetExtreme() {
      click.Play(0);

      previous.color = unselectedColor;
      extremeText.color = selectedColor;
      previous = extremeText;

        Difficulty.level = 3;
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
