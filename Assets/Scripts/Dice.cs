using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Animator animator;

    public bool idle = true;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.OnDiceIdle += onIdleChanged;

        animator.SetBool("Idle", idle);
    }

    void OnDestroy(){
        EventManager.instance.OnDiceIdle -= onIdleChanged;
    }

    void onIdleChanged(bool newIdle){
        idle = newIdle;

        animator.SetBool("Idle", idle);

        if(!idle){
            animator.SetFloat("Rolling", Random.Range(0.0f, 3.0f));
        }
    }
}
