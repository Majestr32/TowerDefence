using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretMenuPannel : MonoBehaviour
{
    public static TurretMenuPannel Instance { get; private set; }
    [SerializeField]
    private GameObject turretMenu;
    [SerializeField]
    private GameObject turretStatusContent;
    [SerializeField]
    private Text txtCoins;
    [SerializeField]
    private Text txtWoods;
    [SerializeField]
    private Text txtBricks;
    [SerializeField]
    private Text txtBuildTime;
    private void Awake()
    {
        #region Singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        #endregion
    }
    public void OpenPlanningMenu()
    {
        turretMenu.SetActive(true);
    }
    public void CloseTurretMenu()
    {
        turretMenu.SetActive(false);
    }
    public void ShowTowerStatusContent(int index)
    {
        Debug.Log("Works");
        turretStatusContent.SetActive(true);
        TowersManager.Instance.SelectedTowerIndex = index;

        Turret selectedTurret = TowersManager.Instance.Towers[index].GetComponent<Turret>();
        txtCoins.text = selectedTurret.Levels[0].coinsPrice.ToString();
        txtWoods.text = selectedTurret.Levels[0].woodsPrice.ToString();
        txtBricks.text = selectedTurret.Levels[0].bricksPrice.ToString();
        txtBuildTime.text = TimeSpan.FromSeconds(selectedTurret.Levels[0].timeOnBuild).ToString(@"mm\:ss");
    }
    public void HideTowerStatusContent()
    {
        turretStatusContent.SetActive(false);
    }
}
