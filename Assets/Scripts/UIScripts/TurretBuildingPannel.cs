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
    [SerializeField]
    private ProgressBar processBar;

    [SerializeField]
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
        {
            boundPlan.OnWorkersCountChanghed -= HandleWorkersChanged;
            boundPlan.OnTimeOnBuildingChanged -= HandleTimeOnBuildingChanged;
        }
            
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) && boundPlan != null)
            boundPlan.TimeLeft -= Time.deltaTime;
    }

    public void Bind(BuildingPlan buildingPlan)
    {
        if (buildingPlan != null)
        {
            buildingPlan.OnWorkersCountChanghed -= HandleWorkersChanged;
            buildingPlan.OnTimeOnBuildingChanged -= HandleTimeOnBuildingChanged;
        }

        boundPlan = buildingPlan;

        if(boundPlan != null)
        {
            boundPlan.OnWorkersCountChanghed += HandleWorkersChanged;
            buildingPlan.OnTimeOnBuildingChanged += HandleTimeOnBuildingChanged;
            HandleWorkersChanged(boundPlan.WorkersCount);
            HandleTimeOnBuildingChanged(boundPlan.TimeOnBuilding, boundPlan.TimeLeft);
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
    public void HandleTimeOnBuildingChanged(float totalTime,float timeLeft)
    {
        if(boundPlan != null)
        {
            processBar.BarValue = (int)((totalTime - timeLeft) / totalTime * 100);
            txtTimeLeft.text = "Time left:" + ((int)timeLeft).ToString();
            if (timeLeft <= 0.1f)
                boundPlan.FinishBuilding();
        }
    }
    public void HandleWorkersChanged(int workers)
    {
        if(boundPlan != null)
        {
            txtBuildersCount.text = workers.ToString();
        }
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
