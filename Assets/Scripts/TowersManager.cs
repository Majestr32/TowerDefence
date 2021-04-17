using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersManager : MonoBehaviour
{
    public static TowersManager Instance { get; private set; }
    public GameObject[] Towers;
    public Vector3 SelectedCellPosition { get; set; }
    [SerializeField]
    private Transform towersParent;
    public int SelectedTowerIndex { get; set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    public void Place()
    {
        int playerCoins = PlayerData.Instance.Coins;
        int requiredCoins = Towers[SelectedTowerIndex].GetComponent<Turret>().Levels[0].coinsPrice;
        if (playerCoins >= requiredCoins)
        {
            PlayerData.Instance.WasteCoins(requiredCoins);
            Instantiate(Towers[SelectedTowerIndex], SelectedCellPosition, Quaternion.identity, towersParent);
            UI.Instance.CloseTurretMenu();
        }
    }
}
