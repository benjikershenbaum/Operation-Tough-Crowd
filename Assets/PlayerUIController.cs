using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUIController : MonoBehaviour
{
    // Start is called before the first frame update
    public Image AbilityBar;
    public Image Alert;
    
    public void SetAlert(bool alertState) {
      Alert.gameObject.SetActive(alertState);
    }
    public void UpdateAbilityBar(float newValue) {
      AbilityBar.fillAmount = newValue;
    }
    void Start()
    {
        SetAlert(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
