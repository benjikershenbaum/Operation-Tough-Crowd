using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject x_marker;
    private GameObject x_mark;
    private float playerRadius = 0.5f;
    private LayerMask aiSpecialMask = 1 << 8;
    private LayerMask playerMask = 1 << 9;
    private GameObject manager;
    private bool win;

    private bool foundAISpecial, foundPlayer, foundAI;
    private Transform opponent, ai;

    private bool equiped = false;
    public PlayerUIController playerui;

    private bool isSecondPlayer;
    // Start is called before the first frame update
    void Start()
    {
        isSecondPlayer = transform.GetComponent<PlayerController>().isSecondPlayer;
        manager = GameObject.Find("Manager");
    }
    private void interact() {
        Collider2D[] results = Physics2D.OverlapCircleAll(transform.position, playerRadius);

        foreach (Collider2D r in results)
        {
            if (r.transform.tag == "Untagged")
            {
                continue;
            }
            else if (r.transform.tag == "AISpecial" && !foundAISpecial)
            {
                foundAISpecial = true;
            }
            else if (r.transform.tag == "AI" && !foundAI)
            {
                foundAI = true;
                ai = r.transform;
            }
            else if (r.transform.tag == "Player" && !foundPlayer && !(r.transform.Equals(transform)))
            {
                foundPlayer = true;
                opponent = r.transform;
            }
        }

        if (foundAISpecial && !equiped)
        {
            Debug.Log("KNIFE");
            equiped = true;
            playerui.SetAlert(true);
            manager.GetComponent<AlertSound>().soundAlert();
        }
        else if (foundPlayer && equiped)
        {
            Debug.Log("KILL PLAYER");
            equiped = false;
            Destroy(opponent.gameObject);
            playerui.SetAlert(false);
            manager.GetComponent<Win>().win(!isSecondPlayer);
            manager.GetComponent<FallSound>().soundFall();


        }
        else if (foundAI && equiped)
        {
            Debug.Log("KILL AI");
            equiped = false;
            Debug.Log(manager);
            manager.GetComponent<XManager>().place_marker(ai.transform.position);
            manager.GetComponent<XManager>().flash();
            Destroy(ai.gameObject);
            playerui.SetAlert(false);
            playerui.SetAlert(false);
            manager.GetComponent<FallSound>().soundFall();
        }


        foundAISpecial = false;
        foundPlayer = false;
        foundAI = false;

        ai = null;
        opponent = null;

    }
    // Update is called once per frame
    void Update()
    {
        if (!isSecondPlayer)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                interact();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                interact();
            }
        }
    }
}
