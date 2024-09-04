using System.Collections.Generic;
using UnityEngine;

public class LevelData 
{
    private int _totalTime;// in seconds
    private List<List<Layer>> layers = new List<List<Layer>>();
    private List<int> locks = new List<int>();

    public static LevelData Instance { get; private set; }

    public void OnCreate()
    {
        if (Instance == null) { Instance = this; } 
    }


    public void TakeTime(int time)
    {
        _totalTime = time;
    }

    public void GetLayersAndLockForSlot(List<Layer> slots,int lockedFor)
    {
        layers.Add(slots);
        locks.Add(lockedFor);
    }

    public List<List<Layer>> GetAllLayers() { return layers; }
    public List<int> GetAllLocks() {  return locks; }
    public int GetTime() { return _totalTime; }
}
