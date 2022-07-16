using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Game States
public enum GameState { PAUSED, NOT_PAUSED }

public delegate void OnStateChangeHandler();

public class GameManager: MonoBehaviour {
	public static GameManager instance = null;

	public GameState gameState { get; private set; }

    public int currentHearts = 4;
    public int maximumHearts = 6;

    private Dictionary<string, int> inventory;

    private int currentLevel = 1;

    public void SetGameState(GameState state){
		this.gameState = state;
    }

    void Awake()
    {
        if (instance == null){
            instance = this;
            inventory = new Dictionary<string, int>(){};
            DontDestroyOnLoad(this.gameObject);
            StartCoroutine(CanvasInformation());
            SceneManager.sceneLoaded += UpdateCanvasInformation;
        }
        else
        {
            Object.Destroy(this);
            return;
        }
    }

    void Start(){
    }

    void OnDestroy(){
    }

    public void AddToInventory(Collectable item)
    {
        if (inventory.ContainsKey(item.name))
        {
            inventory[item.name] = inventory[item.name] + 1;
        }
        else
        {
            inventory.Add(item.name, 1);
        }
    }

    public void AddLevel()
    {
        currentLevel++;
    }

    public void UpdateCanvasInformation(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1) StartCoroutine(CanvasInformation());
    }
    

    private IEnumerator CanvasInformation()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        int childs = canvas.transform.childCount;
        canvas.transform.GetChild(childs - 1).GetChild(6).GetComponent<TextMeshProUGUI>().text =
            "Floor " + currentLevel;
        canvas.transform.GetChild(childs - 1).GetChild(8).GetComponent<TextMeshProUGUI >().text = "x" + currentHearts;
        canvas.transform.GetChild(childs - 1).GetChild(10).GetComponent<TextMeshProUGUI >().text = "x" + (inventory.ContainsKey("Clover")? inventory["Clover"] : 0);
        canvas.transform.GetChild(childs - 1).GetChild(12).GetComponent<TextMeshProUGUI>().text =
            "x" + (inventory.ContainsKey("Horseshoe") ? inventory["Horseshoe"] : 0);
        yield return new WaitForSeconds(5.0f);
        
        canvas.transform.GetChild(childs-1).gameObject.SetActive(false);
    }
}
