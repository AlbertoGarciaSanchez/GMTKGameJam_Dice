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
            
		    Invoke("DamageReceivedFinish", 3f);
		    Invoke("ResumeDamage", 3.5f);
        }

    }

    void DamageReceivedFinish(){
        EventManager.instance.OnPauseChangedAction(false);
    }

    void ResumeDamage(){
        damageReceived= false;
    }
}
