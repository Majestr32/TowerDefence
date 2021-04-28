using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesPannel : MonoBehaviour
{
    public static ResourcesPannel Instance { get; private set; }
    [SerializeField]
    private Text txtPlayerCoins;
    [SerializeField]
    private Text txtPlayerWoods;
    [SerializeField]
    private Text txtPlayerBricks;
    [SerializeField]
    private Text txtPlayerWorkers;
    private void Awake()
    {
        #region Singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        #endregion
        PlayerData.Instance.OnBricksChanged += UpdatePlayerBricks;
        PlayerData.Instance.OnCoinsChanged += UpdatePlayerCoins;
        PlayerData.Instance.OnWoodsChanged += UpdatePlayerWoods;
        //Subscribe
    }
    public void UpdatePlayerCoins(int coins)
    {
        txtPlayerCoins.text = coins.ToString();
    }
    public void UpdatePlayerWoods(int woods)
    {
        txtPlayerWoods.text = woods.ToString();
    }
    public void UpdatePlayerBricks(int bricks)
    {
        txtPlayerBricks.text = bricks.ToString();
    }
    public void UpdatePlayerWorkers(int CurrentWorkers,int maximumWorkers)
    {
        txtPlayerWorkers.text = CurrentWorkers.ToString() + "/" + maximumWorkers.ToString();
    }
}
