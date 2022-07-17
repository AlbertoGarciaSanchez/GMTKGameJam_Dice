using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PauseEntity
{
    public int hearts = 2;
    public int maxHearts = 2;
    public int heightHealthBar = 1;
    public HealthBar hB;
    public GameObject hBGO;
    
    // Start is called before the first frame update
    public void Start()
    {
        GameObject go = Instantiate(hBGO, this.transform.position + new Vector3(0, heightHealthBar, 0), Quaternion.identity);
        hB = go.GetComponent<HealthBar>();
        base.Start();
    }
    
    // Start is called before the first frame update
    public void Update()
    {
        base.Update();

        hB.gameObject.transform.position = this.transform.position + new Vector3(0, heightHealthBar, 0);

        if(hearts <= 0){
            Destroy(hB.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void OnDamage(){
        hB.UpdateLife(maxHearts, hearts);
    }
}
