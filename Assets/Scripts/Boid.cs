﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Boid : MonoBehaviour {
    private AnimationHandler animHandle;
    [SerializeField] private float movementSpeed;
    private float idleTime;
    private float toWait;
    private int state;
    private Vector2 movementDirection;
    private Vector2 target;
    public bool isTrain;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag.Contains("AI") || collision.gameObject.tag.Contains("Player"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else {
            state = 0;
        }
    }

    private void Awake() {
        animHandle = GetComponent<AnimationHandler>();
        state = 0;

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
            transform.position = new Vector3(Random.Range(-3.5f, 5.6f), Random.Range(-3.2f, 3.2f), -1.0f);

        }
        else
        {
            transform.position = new Vector3(Random.Range(-5.6f, 5.6f), Random.Range(-3.2f, 3.2f), -1.0f);

        }
        changeTarget();
    }

    private void Update() {
        finiteStateMachine();
    }

    private void changeTarget() {
        movementSpeed = 0.5f + Random.Range(-0.2f, 0.1f);
        target += new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-1.0f, 1.0f));
        if (isTrain)
        {
            target = new Vector2(Mathf.Clamp(target.x, -3.5f, 5.6f), Mathf.Clamp(target.y, -3.2f, 3.2f));
        }
        else
        {
            target = new Vector2(Mathf.Clamp(target.x, -5.6f, 5.6f), Mathf.Clamp(target.y, -3.2f, 3.2f));
        }
        movementDirection = Vector3.Normalize(target - new Vector2(transform.position.x, transform.position.y));

        if(movementDirection.x < 0) {
            transform.localScale = new Vector3(-2.0f, 2.0f, 1.0f);
        } else {
            transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
        }
    }

    private void finiteStateMachine() {
        float rand = Random.Range(0.0f, 1.0f);

        switch(state) {
            case 0:
                if(rand < 0.05f) {
                    state = 3;
                } else if(rand < 0.15f) {
                    state = 1;
                    animHandle.isWalking = false;
                    toWait = Random.Range(5.0f, 15.0f);
                } else {
                    state = 2;
                    animHandle.isWalking = true;
                    changeTarget();
                }

                break;
            case 1:
                idleTime += Time.deltaTime;

                if(idleTime > toWait) {
                    idleTime = 0;
                    state = 0;
                }

                break;
            case 2:
                if(move()) {
                    state = 0;
                }

                break;
            case 3:
                StartCoroutine(wave());
                state = 4;

                break;
            default:
                break;
        }
    }

    private bool move() {
        if(Vector2.SqrMagnitude(new Vector2(transform.position.x, transform.position.y) - target) < 0.2f) {
            changeTarget();
            return true;
        }

        transform.position += new Vector3(movementDirection.x, movementDirection.y, 0.0f) * movementSpeed * Time.deltaTime;
        return false;
    }

    public void stop() {
        state = 1;
        toWait = Random.Range(1.0f, 3.0f);
        idleTime = 0.0f;
        animHandle.isWalking = false;
    }

    private IEnumerator wave() {
        animHandle.isWaving = true;

        yield return new WaitForSeconds(3.0f);

        animHandle.isWaving = false;
        state = 0;
    }
}