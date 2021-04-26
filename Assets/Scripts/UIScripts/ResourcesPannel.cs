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
    }
    public void UpdatePlayerCoins()
    {
        txtPlayerCoins.text = PlayerData.Instance.Coins.ToString();
    }
    public void UpdatePlayerWoods()
    {
        txtPlayerWoods.text = PlayerData.Instance.Woods.ToString();
    }
    public void UpdatePlayerBricks()
    {
        txtPlayerBricks.text = PlayerData.Instance.Bricks.ToString();
    }
    public void UpdatePlayerWorkers()
    {
        txtPlayerWorkers.text = PlayerData.Instance.WorkersCount.ToString() + "/" + PlayerData.Instance.MaximumWorkersCount.ToString();
    }
}
