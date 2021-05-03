using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSelectController : MonoBehaviour
{
    public static event Action<BuildingPlan> OnSelectedBuildingPlanChanged;
    public static BuildingPlan SelectedBuildingPlan { get; private set; }
    public static void ChangeBuildingPlan(BuildingPlan plan)
    {
         OnSelectedBuildingPlanChanged?.Invoke(plan);
    }
}
