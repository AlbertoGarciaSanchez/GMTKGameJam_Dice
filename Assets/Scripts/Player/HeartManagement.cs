using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class HeartManagement : MonoBehaviour
{
    public string diceSlotTagName = "DiceSlot";
    public GameObject heartPrefab;
    public List<GameObject> heartSlots = new List<GameObject>(){};
    public List<GameObject> heartsObjects = new List<GameObject>(){};
    public List<int> diceRolls = new List<int>(){};
    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.OnPauseChanged += pauseChanged;
        EventManager.instance.OnStopRolling += stopRolling;
        EventManager.instance.OnHeartUp += onHeartUp;

        // Get slots
        heartSlots = new List<GameObject>(GameObject.FindGameObjectsWithTag(diceSlotTagName));
        // Sort slots by name
        heartSlots = heartSlots.OrderBy(go=>go.name).ToList();

        regenerateHearts();
    }

    void OnDestroy(){
        EventManager.instance.OnPauseChanged -= pauseChanged;
        EventManager.instance.OnStopRolling -= stopRolling;
        EventManager.instance.OnHeartUp -= onHeartUp;
    }

    void onHeartUp(){
        GameManager.instance.currentHearts += 1;

        regenerateHearts();
    }

    void pauseChanged(bool pause)
    {
        if(pause){
            background.SetActive(true);

            EventManager.instance.OnDiceIdleAction(false);

            diceRolls = new List<int>(){};
            for(int i = 0; i < GameManager.instance.currentHearts; i++){
                int val = Random.Range(1, 7);
                diceRolls.Add(val);
            }
        }else{
            regenerateHearts();

            background.SetActive(false);
        }
    }

    void stopRolling(){
        for(int i = 0; i < diceRolls.Count; i++){
            int rolledDiceValue = diceRolls[i];

            if(rolledDiceValue == 6){
                GameManager.instance.currentHearts -= 1;

                heartsObjects[i].GetComponent<Dice>().animator.SetBool("Destroy", true);
            }else{
                heartsObjects[i].GetComponent<Dice>().animator.SetBool("Saved", true);
            }
        }

        if (GameManager.instance.currentHearts == 0)
        {
            //Defeat. Go to result screen.
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }

        //EventManager.instance.OnDiceIdleAction(true);
    }

    void regenerateHearts(){
        for(int i = 0; i < heartsObjects.Count; i++){
            Destroy(heartsObjects[i]);
        }

        heartsObjects = new List<GameObject>(){};

        for(int i = 0; i < GameManager.instance.currentHearts; i++){
            GameObject go = heartSlots[i];

            GameObject instantiateObject = Instantiate (heartPrefab, go.transform.position, transform.rotation);
            instantiateObject.transform.SetParent(heartSlots[i].transform);

            instantiateObject.transform.localScale = new Vector3(1.75f, 1.5f, 1f);

            // Instantiate Dice hearts
            heartsObjects.Add(instantiateObject);
        }
    }
}
