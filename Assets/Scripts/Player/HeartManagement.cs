using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HeartManagement : MonoBehaviour
{
    public string diceSlotTagName = "DiceSlot";
    public GameObject heartPrefab;
    public List<GameObject> heartSlots = new List<GameObject>(){};
    public List<GameObject> heartsObjects = new List<GameObject>(){};
    public List<int> diceRolls = new List<int>(){};

    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.OnPauseChanged += pauseChanged;

        // Get slots
        heartSlots = new List<GameObject>(GameObject.FindGameObjectsWithTag(diceSlotTagName));
        // Sort slots by name
        heartSlots = heartSlots.OrderBy(go=>go.name).ToList();

        regenerateHearts();
    }

    void OnDestroy(){
        EventManager.instance.OnPauseChanged -= pauseChanged;
    }

    void pauseChanged(bool pause)
    {
        if(pause){
            EventManager.instance.OnDiceIdleAction(false);

            diceRolls = new List<int>(){};
            for(int i = 0; i < GameManager.instance.currentHearts; i++){
                int val = Random.Range(1, 7);
                Debug.Log(val);
                diceRolls.Add(val);
            }
        }else{
            
            for(int i = 0; i < diceRolls.Count; i++){
                int rolledDiceValue = diceRolls[i];

                if(rolledDiceValue == 6){
                    GameManager.instance.currentHearts -= 1;
                }
            }

            regenerateHearts();

            EventManager.instance.OnDiceIdleAction(true);
        }
    }

    void regenerateHearts(){
        for(int i = 0; i < heartsObjects.Count; i++){
            Destroy(heartsObjects[i]);
        }

        for(int i = 0; i < GameManager.instance.currentHearts; i++){
            GameObject go = heartSlots[i];

            GameObject instantiateObject = Instantiate (heartPrefab, go.transform.position, transform.rotation);
            instantiateObject.transform.SetParent(this.transform);

            // Instantiate Dice hearts
            heartsObjects.Add(instantiateObject);
        }
    }
}