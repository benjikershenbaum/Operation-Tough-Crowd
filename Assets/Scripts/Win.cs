using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Win : MonoBehaviour
{
    [SerializeField] private GameObject p1win;
    [SerializeField] private GameObject p2win;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject replayButton;


    private void Start()
    {
        p1win.SetActive(false);
        p2win.SetActive(false);
        menuButton.SetActive(false);
        menuButton.SetActive(false);
    }

    public void win(bool p1won) {
        if (p1won) {
            p1win.SetActive(true);
        }
        else {
            p2win.SetActive(true);
        }
        menuButton.SetActive(true);
        replayButton.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
