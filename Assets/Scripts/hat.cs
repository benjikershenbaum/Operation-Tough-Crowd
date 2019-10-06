using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hat : MonoBehaviour
{
    public GameObject[] hats;
    public float period = 0f;
    public float nextAction = 1f;
    // Start is called before the first frame update
    void changeHat() {
      int hat_num = Random.Range(0,hats.Length+1);
      if (hat_num < hats.Length) {
        hats[hat_num].SetActive(true);      
        }  
    }
    void Start()
    {
     changeHat();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
