using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public bool damageReceived = false;
    public Transform enemyTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Replace with OnTriggerEnter2D
    void Update()
    {
        // TO BE REMOVED
        /*if(Input.GetKeyDown(KeyCode.Escape)){
            damageReceived= true;

            EventManager.instance.OnPauseChangedAction(true);
            
		    Invoke("StopRolling", 2f);
		    Invoke("DamageReceivedFinish", 4f);
		    Invoke("ResumeDamage", 5f);
        }*/
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Minotaur enemy = col.gameObject.GetComponent<Minotaur>();
        if(!damageReceived && enemy is Minotaur){
            damageReceived = true;
            enemyTransform = col.gameObject.transform;

            OnDamage();

            return;
        }
    }

    public void OnDamage(){
        EventManager.instance.OnPauseChangedAction(true);
        
        Invoke("StopRolling", 2f);
        Invoke("DamageReceivedFinish", 4f);
        Invoke("ResumeDamage", 5f);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(!damageReceived){
            OnTriggerEnter2D(other);
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
