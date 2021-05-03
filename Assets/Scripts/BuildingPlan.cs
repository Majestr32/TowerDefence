using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlan : MonoBehaviour
{
    private Turret turretToBuild;
    public float TurretDamage { get; private set; }
    public float TurretSpeed { get; private set; }
    [SerializeField]
    private float timeLeft;
    [SerializeField]
    private float timeOnBuilding;
    private int workersCount;
    public int WorkersCount { get => workersCount; set { workersCount = value; OnWorkersCountChanghed?.Invoke(value); } }
    public float TimeLeft { get => timeLeft; set { timeLeft = value; OnTimeOnBuildingChanged?.Invoke(timeOnBuilding, value); } }
    public float TimeOnBuilding { get => timeOnBuilding; set { timeOnBuilding = value; OnTimeOnBuildingChanged?.Invoke(value,timeLeft); } }

    public event Action<int> OnWorkersCountChanghed;
    public event Action<float,float> OnTimeOnBuildingChanged; 

    private void Awake()
    {
        turretToBuild = GetComponent<Turret>();
        TurretDamage = turretToBuild.Levels[0].bullet.damage;
        TurretSpeed = turretToBuild.Levels[0].bullet.speed;
        TimeLeft = timeOnBuilding;
    }
    public void FinishBuilding()
    {
        Debug.Log("Building Finished");
        TurretBuildingPannel.Instance.HideTurretBuildingPannel();
        turretToBuild.enabled = true;
        this.enabled = false;
        ClickSelectController.ChangeBuildingPlan(null);
    }
    private void OnMouseDown()
    {
        if (!this.enabled)
            return;
        TurretBuildingPannel.Instance.ShowTurretBuildingPannel(this);
        ClickSelectController.ChangeBuildingPlan(this);

    }
    private void Update()
    {
        
    }
}
