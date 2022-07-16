using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public bool damageReceived = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Replace with OnTriggerEnter2D
    void Update()
    {
        // TO BE REMOVED
        if(Input.GetKeyDown(KeyCode.Escape)){
            damageReceived= true;

            EventManager.instance.OnPauseChangedAction(true);
            
		    Invoke("StopRolling", 2f);
		    Invoke("DamageReceivedFinish", 4f);
		    Invoke("ResumeDamage", 4.5f);
        }

    }

    void StopRolling(){
        EventManager.instance.OnStopRollingAction();
    }

    void DamageReceivedFinish(){
        EventManager.instance.OnPauseChangedAction(false);
    }

    void ResumeDamage(){
        damageReceived= false;
    }
}
