using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }
    [Header("Wave Pannel")]
    private Text txtWave;
    private GameObject objWave;
    [Header("Exit Pannel")]
    private GameObject objExitPannel;
    [Header("Win Pannel")]
    private GameObject objLosePannel;
    private GameObject objWinPannel;
    [Header("Resources pannel")]
    private GameObject playerResourcesPannel;
    private Text txtPlayerCoins;
    private Text txtPlayerWoods;
    private Text txtPlayerBricks;
    [Header("Turret Menu")]
    private GameObject turretMenu;
    private GameObject turretStatusContent;
    private GameObject turretResourcesPannel;
    private Text txtCoins;
    private Text txtWoods;
    private Text txtBricks;
    private Text txtBuildTime;
    private void Awake()
    {
        #region Singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        #endregion
        AddReferences();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            ShowExitMenu();
    }
    #region References
    private void AddReferences()
    {
        AddPlayerResourcesPannelReference();
        AddTurretMenuReferences();
        AddWavePannelReferences();
        AddWinningPannelReferences();
        AddExitPannelReferences();
    }
    private void AddPlayerResourcesPannelReference()
    {
        playerResourcesPannel = transform.Find("resourcesPannel").gameObject;
        txtPlayerCoins = playerResourcesPannel.transform.Find("coinsPannel").Find("txtCoins").GetComponent<Text>();
        txtPlayerWoods = playerResourcesPannel.transform.Find("woodsPannel").Find("txtWoods").GetComponent<Text>();
        txtPlayerBricks =playerResourcesPannel.transform.Find("bricksPannel").Find("txtBricks").GetComponent<Text>();
    }
    private void AddTurretMenuReferences()
    {
        turretMenu = transform.Find("TurretMenu").gameObject;
        turretStatusContent = turretMenu.transform.Find("TurretStatus").Find("TurretStatusContent").gameObject;
        turretResourcesPannel = turretStatusContent.transform.Find("ResourcesPannel").gameObject;
        txtCoins = turretResourcesPannel.transform.Find("CoinsPannel").Find("txtCoins").GetComponent<Text>();
        txtWoods = turretResourcesPannel.transform.Find("WoodsPannel").Find("txtWoods").GetComponent<Text>();
        txtBricks = turretResourcesPannel.transform.Find("BricksPannel").Find("txtBricks").GetComponent<Text>();
        txtBuildTime = turretResourcesPannel.transform.Find("TimePannel").Find("txtBuildTime").GetComponent<Text>();
    }
    private void AddWavePannelReferences()
    {
        objWave = transform.Find("txtWave").gameObject;
        txtWave = objWave.GetComponent<Text>();
    }
    private void AddWinningPannelReferences()
    {
        objWinPannel = transform.Find("winPannel").gameObject;
        objLosePannel = transform.Find("losePannel").gameObject;
    }
    private void AddExitPannelReferences()
    {
        objExitPannel = transform.Find("exitPanel").gameObject;
    }

    #endregion
    #region ExitMenuUI
    public void ShowExitMenu()
    {
        objExitPannel.SetActive(true);
    }
    public void HideExitMenu()
    {
        objExitPannel.SetActive(false);
    }
    #endregion
    #region SceneManagment
    //I know it must be in GameManager , but i don`t want to create this class
    public void ExitGame()
    {
        Application.Quit();
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion
    #region WinPannelUI
    public void ShowLosePannel()
    {
        objLosePannel.SetActive(true);
    }
    public void ShowWinPannel()
    {
        objWinPannel.SetActive(true);
    }
    #endregion
    #region WaveUI
    public void ShowWave(int wave)
    {
        StartCoroutine(AnimationWave(wave));
    }
    private IEnumerator AnimationWave(int wave)
    {
        objWave.SetActive(true);
        txtWave.text = "Wave " + wave;
        yield return new WaitForSeconds(2f);
        objWave.SetActive(false);
    }
    #endregion
    #region TurretMenuUI
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
    #endregion
    #region PlayerResourcesUI
    public void UpdatePlayerCoins()
    {
        txtPlayerCoins.text = PlayerData.Instance.Coins.ToString();
    }
    #endregion
}
