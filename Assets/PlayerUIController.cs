using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUIController : MonoBehaviour
{
    // Start is called before the first frame update
    public Image AbilityBar;
    public Image Alert;
    public Image Skull1;
    public Image Skull2;
    public Image Skull3;
    private Image[] skulls;
    
    public void SetAlert(bool alertState) {
      Alert.gameObject.SetActive(alertState);
    }
    public void UpdateAbilityBar(float newValue) {
      AbilityBar.fillAmount = newValue;
    }
    public void SetSkull(int skullNum)
    {
        skulls[skullNum].gameObject.SetActive(true);
    }
    void Start()
    {
        SetAlert(false);
        skulls=new Image[3];
        skulls[0] = Skull1;
        skulls[1] = Skull2;
        skulls[2] = Skull3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
