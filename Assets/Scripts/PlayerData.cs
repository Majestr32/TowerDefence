using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance { get; private set; }
    private int coins;
    public int Coins { get { return coins; } set { coins = value; UI.Instance.UpdatePlayerCoins(); }  }
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
    }
    public void ReceiveCoins(int amount)
    {
        Coins += amount;
    }
    public void WasteCoins(int amount)
    {
        Coins -= amount;
    }
}
