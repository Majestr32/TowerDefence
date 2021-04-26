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
        int playerWoods = PlayerData.Instance.Woods;
        int playerBricks = PlayerData.Instance.Bricks;

        int requiredCoins = Towers[SelectedTowerIndex].GetComponent<Turret>().Levels[0].coinsPrice;
        int requiredWoods = Towers[SelectedTowerIndex].GetComponent<Turret>().Levels[0].woodsPrice;
        int requiredBricks = Towers[SelectedTowerIndex].GetComponent<Turret>().Levels[0].bricksPrice;

        if (playerCoins >= requiredCoins && playerBricks >= requiredBricks && playerWoods >= requiredWoods)
        {
            PlayerData.Instance.WasteCoins(requiredCoins);
            PlayerData.Instance.WasteBricks(requiredBricks);
            PlayerData.Instance.WasteWoods(requiredWoods);

            Instantiate(Towers[SelectedTowerIndex], SelectedCellPosition, Quaternion.identity, towersParent);
            TurretMenuPannel.Instance.CloseTurretMenu();
        }
    }
}
