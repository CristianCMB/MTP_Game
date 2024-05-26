using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class BuildingGhost : MonoBehaviour
{

    private GameObject spriteGameObject;

    private void Awake() {
        spriteGameObject = transform.Find("sprite").gameObject;
    }

    private void Start() {
        BuildingManager.Instance.OnActiveBuildingTypeChange += BuildingManager_OnActiveBuildingTypeChanged;
        Hide();
    }

    private void BuildingManager_OnActiveBuildingTypeChanged(object sender, BuildingManager.OnActiveBuildingTypeChangeEventArgs e)
    {
        if (e.activeBuildingType == null) {
            Hide();
        }
        else {
            Show(e.activeBuildingType.sprite);
        }
    }

    private void Update() {
        transform.position = UtilsClass.GetMouseWorldPosition();
    }
    
    private void Show(Sprite ghostSprite) {
        spriteGameObject.gameObject.SetActive(true);
        spriteGameObject.GetComponent<SpriteRenderer>().sprite = ghostSprite;
    }
    
    private void Hide() {
        spriteGameObject.gameObject.SetActive(false);
    }
}
