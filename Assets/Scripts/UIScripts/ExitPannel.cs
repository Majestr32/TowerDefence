using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPannel : MonoBehaviour
{
    public static ExitPannel Instance { get; private set; }
    [SerializeField]
    private GameObject objExitPannel;
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
        if (Input.GetKey(KeyCode.Escape))
            ShowExitMenu();
    }
    public void ShowExitMenu()
    {
        objExitPannel.SetActive(true);
    }
    public void HideExitMenu()
    {
        objExitPannel.SetActive(false);
    }
}
