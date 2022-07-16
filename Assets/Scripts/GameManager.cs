using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

// Game States
public enum GameState { PAUSED, NOT_PAUSED }

public delegate void OnStateChangeHandler();

public class GameManager: MonoBehaviour {
	public static GameManager instance = null;

	public GameState gameState { get; private set; }

    public int currentHearts = 4;
    public int maximumHearts = 6;

    private Dictionary<string, int> inventory;

    public void SetGameState(GameState state){
		this.gameState = state;
    }

    void Awake()
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else
            Object.Destroy(this);
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
}
