using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }
    [SerializeField]
    private ExitPannel exitPannel;
    [SerializeField]
    private ResourcesPannel resourcesPannel;
    [SerializeField]
    private TurretBuildingPannel turretBuildingPannel;
    [SerializeField]
    private TurretMenuPannel turretMenuPannel;
    [SerializeField]
    private WinPannel winPannel;
    [SerializeField]
    private WavePannel wavePannel;
    [SerializeField]
    private void Awake()
    {
        #region Singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        #endregion
        ClickSelectController.OnSelectedBuildingPlanChanged += HandleSelectedBuildingPlanChanged;
        HandleSelectedBuildingPlanChanged(ClickSelectController.SelectedBuildingPlan);
    }
    private void HandleSelectedBuildingPlanChanged(BuildingPlan plan)
    {
        if (turretBuildingPannel != null)
            turretBuildingPannel.Bind(plan);
    }
    private void Update()
    {

    }
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
}
