using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretBuildingPannel : MonoBehaviour
{
    public static TurretBuildingPannel Instance { get; private set; }
    [SerializeField]
    private GameObject turretBuildingPannel;
    [SerializeField]
    private GameObject turretData;
    [SerializeField]
    private GameObject buildingData;
    [SerializeField]
    private Image imgTurret;
    [SerializeField]
    private Text txtTurretBuildingDamage;
    [SerializeField]
    private Text txtTurretBuildingSpeed;
    [SerializeField]
    private Text txtBuildersCount;
    [SerializeField]
    private Text txtTimeLeft;

    private BuildingPlan boundPlan;
    private void Awake()
    {
        #region Singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        #endregion

    }
    private void OnDestroy()
    {
        if (boundPlan != null)
            boundPlan.OnWorkersCountChanghed -= HandleWorkersChanged;
    }

    public void Bind(BuildingPlan buildingPlan)
    {
        if (buildingPlan != null)
            buildingPlan.OnWorkersCountChanghed -= HandleWorkersChanged;

        boundPlan = buildingPlan;

        if(boundPlan != null)
        {
            boundPlan.OnWorkersCountChanghed += HandleWorkersChanged;
            HandleWorkersChanged(boundPlan.WorkersCount);
        }
    }

    public void AddWorker()
    {
        if(boundPlan != null && PlayerData.Instance.WorkersCount > 0)
        {
            //Subtract from player
            //add to the boundPlan
        }

    }
    public void RemoveWorker()
    {
        if(boundPlan != null && boundPlan.WorkersCount >= 0)
        {
            //Add to the player
            //Subtract from boundPlan
        }
    }

    public void HandleWorkersChanged(int workers)
    {
        txtBuildersCount.text = workers.ToString();
    }
    public void ShowTurretBuildingPannel(BuildingPlan buildingPlan)
    {
        turretBuildingPannel.SetActive(true);
        imgTurret.sprite = buildingPlan.GetComponent<SpriteRenderer>().sprite;
        txtTurretBuildingDamage.text = "Damage: " + buildingPlan.TurretDamage;
        txtTurretBuildingSpeed.text = "Speed: " + buildingPlan.TurretSpeed;
        txtBuildersCount.text = buildingPlan.WorkersCount.ToString();
        txtTimeLeft.text = "Time left: " + buildingPlan.TimeLeft;
    }
    public void HideTurretBuildingPannel()
    {
        turretBuildingPannel.SetActive(false);
    }
}
