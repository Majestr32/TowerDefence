using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPannel : MonoBehaviour
{
    public static WinPannel Instance { get; private set; }
    [SerializeField]
    private GameObject objLosePannel;
    [SerializeField]
    private GameObject objWinPannel;

    private void Awake()
    {
        #region Singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        #endregion

    }
    public void ShowLosePannel()
    {
        objLosePannel.SetActive(true);
    }
    public void ShowWinPannel()
    {
        objWinPannel.SetActive(true);
    }
}
