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
    private static ExitPannel exitPannel;
    [SerializeField]
    private static ResourcesPannel resourcesPannel;
    [SerializeField]
    private static TurretBuildingPannel turretBuildingPannel;
    [SerializeField]
    private static TurretMenuPannel turretMenuPannel;
    [SerializeField]
    private static WinPannel winPannel;
    [SerializeField]
    private static WavePannel wavePannel;
    [SerializeField]
    private void Awake()
    {
        #region Singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        #endregion
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
