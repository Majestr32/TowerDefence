using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance { get; private set; }
    private int coins;
    private int woods;
    private int bricks;
    private int workersCount;
    private int maximumWorkersCount;
    public int WorkersCount { get { return workersCount; } set { workersCount = value; ResourcesPannel.Instance.UpdatePlayerWorkers(); } }
    public int MaximumWorkersCount { get { return maximumWorkersCount; } set { maximumWorkersCount = value; ResourcesPannel.Instance.UpdatePlayerWorkers(); } }
    public int Coins { get { return coins; } set { coins = value; ResourcesPannel.Instance.UpdatePlayerCoins(); }  }
    public int Woods { get { return woods; } set { woods = value; ResourcesPannel.Instance.UpdatePlayerWoods(); } }
    public int Bricks { get { return bricks; } set { bricks = value; ResourcesPannel.Instance.UpdatePlayerBricks(); } }
    private void Awake()
    {
        #region Singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        #endregion
    }
    private void Start()
    {
        Coins = 100;
        Woods = 50;
        Bricks = 50;
        MaximumWorkersCount = 3;
        WorkersCount = 2;
    }
    public void ReceiveCoins(int amount)
    {
        Coins += amount;
    }
    public void WasteCoins(int amount)
    {
        Coins -= amount;
    }
    public void WasteWoods(int amount)
    {
        Woods -= amount;
    }
    public void WasteBricks(int amount)
    {
        Bricks -= amount;
    }
}
