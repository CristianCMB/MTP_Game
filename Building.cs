using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private HealthSystem healthSystem;
    private BuildingTypeSO buildingType;
    private void Start() {
       buildingType=  GetComponent<BuildingTypeHolder>().buildingType;

        healthSystem = GetComponent<HealthSystem>();

        healthSystem.OnDied += HealthSystem_Ondied;

        healthSystem.SetHealthAmountMax(buildingType.healthAmountMax, true);
    }

    private void Update()
    {
    }

    private void HealthSystem_Ondied(object sender, System.EventArgs e) {
        Destroy(gameObject);
    }
}


