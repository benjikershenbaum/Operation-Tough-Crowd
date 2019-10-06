using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {
    [SerializeField] private GameObject npc;
    [SerializeField] private int [] diffs;
    [SerializeField] private int numAI;
    private static List<Transform> npcs = new List<Transform>();

    private void Start() {
        numAI = diffs[Difficulty.level];
        for(int i = 0; i < numAI; i++) {
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
