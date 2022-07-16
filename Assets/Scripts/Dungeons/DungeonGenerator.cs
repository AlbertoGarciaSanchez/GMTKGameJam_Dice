using System.Collections;
using System.Collections.Generic;
using GamePX;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public GameObject world;
    public int dungeonSize;
    public int depth;
    public DungeonStorage storage;

    private SquaredDungeon _squaredDungeon;
    // Start is called before the first frame update
    void Start()
    {
        _squaredDungeon = new SquaredDungeon(dungeonSize);
        _squaredDungeon.SetRandom(new ExtendedRandom());
        _squaredDungeon.Generate();

        ListUtil<GameObject>[] allRoomsAvailable = storage.GetAllRooms();

        List<List<double>> allChances = storage.GetAllChances();

        List<GameObject> startingRooms = storage.GetAllStartingRooms();
        
        List<GameObject> endingRooms = storage.GetAllEndingRooms();

        _squaredDungeon.PopulateDungeonFromTable(world, allRoomsAvailable, allChances, depth, true, startingRooms, endingRooms);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
