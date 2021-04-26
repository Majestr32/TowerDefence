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
    private void Awake()
    {
        #region Singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        #endregion
        HideTurretBuildingPannel();
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
