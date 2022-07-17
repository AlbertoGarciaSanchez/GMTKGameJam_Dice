using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
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
        Enemy enemy = col.gameObject.GetComponent<Enemy>();
        if(enemy != null && enemy is Enemy && !listGameObjectSlashed.Contains(enemy.gameObject)){
            enemy.hearts -= 1;
            enemy.OnDamage();
            listGameObjectSlashed.Add(enemy.gameObject);
        }
    }
}
