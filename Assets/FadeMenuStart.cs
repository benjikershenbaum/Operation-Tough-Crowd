using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeMenuStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Image fade;
    void Start()
    {
        IEnumerator ie = FadeIn();
        StartCoroutine(ie);
    }
    IEnumerator FadeIn() {
      fade.gameObject.SetActive(true);
      for(float i = 1f; i >= 0; i-=0.05f) {
        fade.color = new Color(0f,0f,0f,i);
        yield return new WaitForSeconds(0.01f);
      }
      fade.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
