using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSound : MonoBehaviour
{
    [SerializeField] private GameObject fall;
    // Start is called before the first frame update
    public void soundFall() {
        fall.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
