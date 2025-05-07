using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    VisualElement map;
    VisualElement equipment;
    VisualElement inventory;

    VisualElement mapArrowL;
    VisualElement mapArrowR;
    VisualElement equipmentArrow;
    VisualElement inventoryArrow;

    private void HideContent(){
        map.style.display = DisplayStyle.None;
        equipment.style.display = DisplayStyle.None;
        inventory.style.display = DisplayStyle.None;
    }

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        map = root.Q("Map");
        equipment = root.Q("Equipment");
        inventory = root.Q("Inventory");

        mapArrowL = root.Q("MapArrowL");
        mapArrowR = root.Q("MapArrowR");
        equipmentArrow = root.Q("EquipmentArrow");
        inventoryArrow = root.Q("InventoryArrow");

        // * EQUIPMENT ARROW
        equipmentArrow.RegisterCallback<ClickEvent>(evt =>{
            HideContent();
            map.style.display = DisplayStyle.Flex;
        });

        equipmentArrow.RegisterCallback<MouseEnterEvent>(evt =>{
            equipmentArrow.style.unityBackgroundImageTintColor = Color.gray;
        });

        equipmentArrow.RegisterCallback<MouseLeaveEvent>(evt =>{
            equipmentArrow.style.unityBackgroundImageTintColor = Color.white;

        });

        // * MAP RIGHT ARROW

        mapArrowR.RegisterCallback<ClickEvent>(evt =>{
            HideContent();
            equipment.style.display = DisplayStyle.Flex;
        });

        mapArrowR.RegisterCallback<MouseEnterEvent>(evt =>{
            mapArrowR.style.unityBackgroundImageTintColor = Color.gray;
        });

        mapArrowR.RegisterCallback<MouseLeaveEvent>(evt =>{
            mapArrowR.style.unityBackgroundImageTintColor = Color.white;

        });

        // * MAP LEFT ARROW

        mapArrowL.RegisterCallback<ClickEvent>(evt =>{
            HideContent();
            inventory.style.display = DisplayStyle.Flex;
        });

        mapArrowL.RegisterCallback<MouseEnterEvent>(evt =>{
            mapArrowL.style.unityBackgroundImageTintColor = Color.gray;
        });

        mapArrowL.RegisterCallback<MouseLeaveEvent>(evt =>{
            mapArrowL.style.unityBackgroundImageTintColor = Color.white;

        });

        // * INVENTORY ARROW

         inventoryArrow.RegisterCallback<ClickEvent>(evt =>{
            HideContent();
            map.style.display = DisplayStyle.Flex;
        });

        inventoryArrow.RegisterCallback<MouseEnterEvent>(evt =>{
            inventoryArrow.style.unityBackgroundImageTintColor = Color.gray;
        });

        inventoryArrow.RegisterCallback<MouseLeaveEvent>(evt =>{
            inventoryArrow.style.unityBackgroundImageTintColor = Color.white;

        });

        HideContent();
        equipment.style.display = DisplayStyle.Flex;

    }
}
