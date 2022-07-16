
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePX;

public class DungeonStorage : MonoBehaviour
{
    
    public GameObject[] dungeons_AllDirections;
    public GameObject[] dunegeons_left_top_right;
    public GameObject[] dungeons_top_right_down;
    public GameObject[] dungeons_left_down_right;
    public GameObject[] dungeons_top_left_down;
    public GameObject[] dungeons_top_right;
    public GameObject[] dungeons_top_left;
    public GameObject[] dungeons_down_right;
    public GameObject[] dungeons_down_left;
    public GameObject[] dungeons_top_down;
    public GameObject[] dungeons_right_left;
    public GameObject[] dungeons_top;
    public GameObject[] dungeons_right;
    public GameObject[] dungeons_down;
    public GameObject[] dungeons_left;

    public GameObject startingDungeontop;
    public GameObject startingDungeonright;
    public GameObject startingDungeondown;
    public GameObject startingDungeonleft;
    
    public GameObject endingDungeontop;
    public GameObject endingDungeonright;
    public GameObject endingDungeondown;
    public GameObject endingDungeonleft;
    ListUtil<GameObject>[] allRoomsAvailable = new ListUtil<GameObject>[15];
    public ListUtil<GameObject>[] GetAllRooms()
    {
       
        ListUtil<GameObject> list = new ListUtil<GameObject>();
        list.AddRange(dungeons_AllDirections);
        allRoomsAvailable[0] = list;
        list = new ListUtil<GameObject>();
        list.AddRange(dunegeons_left_top_right);
        allRoomsAvailable[1] = list;
        list = new ListUtil<GameObject>();
        list.AddRange(dungeons_top_right_down);
        allRoomsAvailable[2] = list;
        list = new ListUtil<GameObject>();
        list.AddRange(dungeons_left_down_right);
        allRoomsAvailable[3] = list;
        list = new ListUtil<GameObject>();
        list.AddRange(dungeons_top_left_down);
        allRoomsAvailable[4] = list;
        list = new ListUtil<GameObject>();
        list.AddRange(dungeons_top_right);
        allRoomsAvailable[5] = list;
        list = new ListUtil<GameObject>();
        list.AddRange(dungeons_top_left);
        allRoomsAvailable[6] = list;
        list = new ListUtil<GameObject>();
        list.AddRange(dungeons_down_right);
        allRoomsAvailable[7] = list;
        list = new ListUtil<GameObject>();
        list.AddRange(dungeons_down_left);
        allRoomsAvailable[8] = list;
        list = new ListUtil<GameObject>();
        list.AddRange(dungeons_top_down);
        allRoomsAvailable[9] = list;
        list = new ListUtil<GameObject>();
        list.AddRange(dungeons_right_left);
        allRoomsAvailable[10] = list;
        list = new ListUtil<GameObject>();
        list.AddRange(dungeons_top);
        allRoomsAvailable[11] = list;
        list = new ListUtil<GameObject>();
        list.AddRange(dungeons_right);
        allRoomsAvailable[12] = list;
        list = new ListUtil<GameObject>();
        list.AddRange(dungeons_down);
        allRoomsAvailable[13] = list;
        list = new ListUtil<GameObject>();
        list.AddRange(dungeons_left);
        allRoomsAvailable[14] = list;

        return allRoomsAvailable;
    }

    public List<List<double>> GetAllChances()
    {
        List<List<double>> allChances = new List<List<double>>();
        for (int i = 0; i < 15; i++)
        {
            List<double> chances = new List<double>();
            for (int j = 0; j < allRoomsAvailable[i].Count; j++) chances.Add(1);
            allChances.Add(chances);
        }

        return allChances;
    }
    
    public List<GameObject> GetAllStartingRooms()
    {
        List<GameObject> startingRooms = new List<GameObject>();
        startingRooms.Add(startingDungeontop);
        startingRooms.Add(startingDungeonright);
        startingRooms.Add(startingDungeondown);
        startingRooms.Add(startingDungeonleft);
        return startingRooms;
    }

    public List<GameObject> GetAllEndingRooms()
    {
        List<GameObject> endingRooms = new List<GameObject>();
        endingRooms.Add(endingDungeontop);
        endingRooms.Add(endingDungeonright);
        endingRooms.Add(endingDungeondown);
        endingRooms.Add(endingDungeonleft);
        return endingRooms;
    }
}
