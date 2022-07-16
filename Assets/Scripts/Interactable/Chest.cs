using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    public Sprite chestOpened;
    public Sprite chestClosed;

    public GameObject cloverPrefab;
    public GameObject horseshowPrefab;
    public GameObject dicePrefab;

    public SpriteRenderer sr;
    public LootBox lB;

    public int numberOfLoot = 1;

    public void Start(){
        sr.sprite = chestClosed; 

        lB = gameObject.AddComponent(typeof(LootBox)) as LootBox;
    }

    public override void OnInteract()
    {
        // Update Interacted flag
        base.OnInteract();

        // Change sprite status of the chest to opened.
        sr.sprite = chestOpened; 

        for(int i = 0; i < numberOfLoot; i++){
            // Perform whatever...
            Collectable obtainedItem = lB.ResolveLootBox();

            float radius = 1.5f;
            Vector3 randomPos = Random.insideUnitSphere * radius;
            randomPos += transform.position;
            randomPos.y = 0f;
            
            Vector3 direction = randomPos - transform.position;
            direction.Normalize();
            
            float dotProduct = Vector3.Dot(transform.forward, direction);
            float dotProductAngle = Mathf.Acos(dotProduct / transform.forward.magnitude * direction.magnitude);
            
            randomPos.x = Mathf.Cos(dotProductAngle) * radius + transform.position.x;
            randomPos.y = Mathf.Sin(dotProductAngle * (Random.value > 0.5f ? 1f : -1f)) * radius + transform.position.y;
            randomPos.z = transform.position.z;

            var instantiateObject = Instantiate(obtainedItem.gameObject, transform.position, transform.rotation);
            instantiateObject.transform.position = randomPos;
        }
    }
}
