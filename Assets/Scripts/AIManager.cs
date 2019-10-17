using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AIManager : MonoBehaviour {
    [SerializeField] private bool isMenu;
    [SerializeField] private GameObject npc;
    [SerializeField] private int [] diffs;
    [SerializeField] private int numAI;
    private static List<Transform> npcs = new List<Transform>();
    private bool isTutorial=false;

    private void Start() {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            isTutorial = true;
        }
        if (!isMenu && !isTutorial){
        numAI = diffs[Difficulty.level];

        } else if (isTutorial){
            numAI = 0;
        }
        else
        {
            numAI = 40;
        }
        for (int i = 0; i < numAI; i++) {
            npcs.Add((Instantiate(npc).transform));
      }
    }

    public static void stopAllAI() {
        foreach (Transform npc in npcs)
        {
            if (npc != null)
            {
                npc.GetComponent<Boid>().stop();
            }
        }
    }
}
