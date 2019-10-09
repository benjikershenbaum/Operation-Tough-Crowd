using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {
    private AnimationHandler animHandle;
    public bool isSecondPlayer;
    private float movementSpeed = 0.6f;
    private PlayerAbility ability;
    private float abilityTime = 30f;
    private float timeLeft = 0.0f;
    public PlayerUIController playerui;
    private bool isTrain;


    private void Awake() {
        ability = (PlayerAbility)Activator.CreateInstance(Type.GetType(AddAbility.randomiseAbility()));
        ability = (PlayerAbility)gameObject.AddComponent(ability.GetType());
        animHandle = GetComponent<AnimationHandler>();
    }

    private void Start()
    {

        if (SceneManager.GetActiveScene().name == "Train")
        {
            isTrain = true;
        }
        else
        {
            isTrain = false;
        }

        if (isTrain)
        {
            transform.position = new Vector3(UnityEngine.Random.Range(-3.5f, 5.6f), UnityEngine.Random.Range(-3.2f, 3.2f), -1.0f);

        }
        else
        {
            transform.position = new Vector3(UnityEngine.Random.Range(-5.6f, 5.6f), UnityEngine.Random.Range(-3.2f, 3.2f), -1.0f);

        }

        playerui.UpdateAbilityBar(0);
    }

    private void Update() {
        callWave();
        playerAbility();
        move();
    }

    private void callWave() {
        if(!isSecondPlayer) {
            if(Input.GetKeyDown(KeyCode.X)) {
                StartCoroutine(wave());
            }
        } else {
            if(Input.GetKeyDown(KeyCode.M)) {
                StartCoroutine(wave());
            }
        }
    }

    private Vector2 direction() {
        if(animHandle.isWaving) {
            return Vector2.zero;
        }

        int xMovement = 0;
        int yMovement = 0;

        if(!isSecondPlayer) {
            if(Input.GetKey(KeyCode.A)) {
                xMovement--;
            }

            if(Input.GetKey(KeyCode.D)) {
                xMovement++;
            }

            if(Input.GetKey(KeyCode.S)) {
                yMovement--;
            }

            if(Input.GetKey(KeyCode.W)) {
                yMovement++;
            }
        } else {
            if(Input.GetKey(KeyCode.J)) {
                xMovement--;
            }

            if(Input.GetKey(KeyCode.L)) {
                xMovement++;
            }

            if(Input.GetKey(KeyCode.K)) {
                yMovement--;
            }

            if(Input.GetKey(KeyCode.I)) {
                yMovement++;
            }
        }


        if(xMovement != 0 || yMovement != 0) {
            animHandle.isWalking = true;

            if(xMovement < 0) {
                transform.localScale = new Vector3(-2.0f, 2.0f, 1.0f);
            } else {
                transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
            }
        } else {
            animHandle.isWalking = false;
        }

        return new Vector2(xMovement, yMovement);
    }

    private void move() {
        Vector2 dir = direction();

        if(dir.x < 0) {
            transform.localScale = new Vector3(-2.0f, 2.0f, 1.0f);
        } else {
            transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
        }

        transform.position += new Vector3(dir.x, dir.y, 0.0f) * movementSpeed * Time.deltaTime;
    }

    private void playerAbility() {
        if (timeLeft <= 0)
        {
            if (!isSecondPlayer)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    ability.onCallAbility();
                    timeLeft = 30f;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.N))
                {
                    ability.onCallAbility();
                    timeLeft = 30f;
                }
            }
        }
        else
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = 0;
            }
            playerui.UpdateAbilityBar(timeLeft / abilityTime);
        }
        Debug.Log(timeLeft);
    }

    private IEnumerator wave() {
        animHandle.isWaving = true;

        yield return new WaitForSeconds(2.0f);

        animHandle.isWaving = false;
    }
}