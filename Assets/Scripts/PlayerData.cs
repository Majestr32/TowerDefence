using System;
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
    public int WorkersCount { get { return workersCount; } set { workersCount = value; OnWorkersCountChanged?.Invoke(value,maximumWorkersCount); } }
    public int MaximumWorkersCount { get { return maximumWorkersCount; } set { maximumWorkersCount = value; OnMaximumWorkersCountChanged?.Invoke(workersCount,value); } }
    public int Coins { get { return coins; } set { coins = value; OnCoinsChanged?.Invoke(value); }  }
    public int Woods { get { return woods; } set { woods = value; OnWoodsChanged?.Invoke(value); } }
    public int Bricks { get { return bricks; } set { bricks = value; OnBricksChanged?.Invoke(value); } }
    
    public event Action<int,int> OnWorkersCountChanged;
    public event Action<int,int> OnMaximumWorkersCountChanged;
    public event Action<int> OnCoinsChanged;
    public event Action<int> OnWoodsChanged;
    public event Action<int> OnBricksChanged;
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
}
