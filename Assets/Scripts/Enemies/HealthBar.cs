using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject life;
    public GameObject end;
    public Vector3 maxScale;
    public int maxLifes = -1;
    public int currentLifes = -1;

    // Start is called before the first frame update
    void Start()
    {
        maxScale = life.transform.localScale;
    }

    void Update(){
        life.transform.position = this.transform.position - new Vector3((this.transform.position.x - end.transform.position.x) * (1 - (currentLifes / (float) maxLifes)), 0, 0);
    }

    // Update is called once per frame
    public void UpdateLife(int maxLifes, int currentLifes)
    {
        this.maxLifes = maxLifes;
        this.currentLifes = currentLifes;

        Debug.Log((currentLifes / (float) maxLifes) * maxScale.x);
        life.transform.localScale = new Vector3((currentLifes / (float) maxLifes) * maxScale.x, maxScale.y, maxScale.z);
    }
}
