using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertSound : MonoBehaviour
{
    [SerializeField] private GameObject alert;
    // Start is called before the first frame update
    public void soundAlert() {
        alert.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
