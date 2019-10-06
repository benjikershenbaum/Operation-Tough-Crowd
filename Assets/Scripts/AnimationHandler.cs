using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public bool isWalking; 
    public bool isWaving; 

    public Animator[] childrenObjects;
    public Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking) {
          foreach (Animator a in childrenObjects) {
                        myAnimator.SetBool("is_walking",true);

            a.SetBool("is_walking",true);
          }
        } else {
           foreach (Animator a in childrenObjects) {
            myAnimator.SetBool("is_walking",false);
            a.SetBool("is_walking",false);
          }
        }
        if (isWaving) {
          foreach (Animator a in childrenObjects) {
            myAnimator.SetBool("is_waving",true);
            a.SetBool("is_waving",true);
          }
        } else {
           foreach (Animator a in childrenObjects) {
            myAnimator.SetBool("is_waving",false);
            a.SetBool("is_waving",false);
          }
        }
    }
}
