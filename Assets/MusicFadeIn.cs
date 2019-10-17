using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeIn : MonoBehaviour
{
    public AudioSource[] players;
    // Start is called before the first frame update
    void Start()
    {
        IEnumerator ie = FadeMusic();
        StartCoroutine(ie);
    }
    IEnumerator FadeMusic() {
      for (float volumeAmount = 0f; volumeAmount <= 0.75f; volumeAmount+=0.01f){
        foreach(AudioSource p in players) {
          p.volume = volumeAmount;
          yield return new WaitForSeconds(0.05f);
        }
      } 
      
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
