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
    public int WorkersCount { get; private set; }
    public float TimeLeft { get => timeLeft; }

    private void Awake()
    {
        turretToBuild = GetComponent<Turret>();
        TurretDamage = turretToBuild.Levels[0].bullet.damage;
        TurretSpeed = turretToBuild.Levels[0].bullet.speed;
    }
    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        TurretBuildingPannel.Instance.ShowTurretBuildingPannel(this);
    }
    private void Update()
    {
        
    }
}
