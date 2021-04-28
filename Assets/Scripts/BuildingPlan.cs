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
    private int timeLeft;
    private int workersCount;
    public int WorkersCount { get => workersCount; set { workersCount = value; OnWorkersCountChanghed?.Invoke(value); } }
    public float TimeLeft { get => timeLeft; }

    public event Action<int> OnWorkersCountChanghed;

    private void Awake()
    {
        turretToBuild = GetComponent<Turret>();
        TurretDamage = turretToBuild.Levels[0].bullet.damage;
        TurretSpeed = turretToBuild.Levels[0].bullet.speed;
    }
    private void OnMouseDown()
    {
        TurretBuildingPannel.Instance.ShowTurretBuildingPannel(this);
        ClickSelectController.ChangeBuildingPlan(this);

    }
    private void Update()
    {
        
    }
}
