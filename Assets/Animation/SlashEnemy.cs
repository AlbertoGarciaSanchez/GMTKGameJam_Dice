using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEnemy : MonoBehaviour
{
    private List<GameObject> listGameObjectSlashed = new List<GameObject>(){};

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 1f);
    }

    void DestroySelf(){
        Destroy(this.gameObject);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        DamageManager enemy = col.gameObject.GetComponent<DamageManager>();
        if(enemy != null && enemy is DamageManager && !listGameObjectSlashed.Contains(enemy.gameObject)){
            enemy.OnDamage();

            listGameObjectSlashed.Add(enemy.gameObject);
        }
    }
}
