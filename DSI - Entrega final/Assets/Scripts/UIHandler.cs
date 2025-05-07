using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    VisualElement map;
    VisualElement equipment;

    VisualElement mapArrowL;
    VisualElement mapArrowR;
    VisualElement equipmentArrow;

    private void HideContent(){
        map.style.display = DisplayStyle.None;
        equipment.style.display = DisplayStyle.None;
        // TODO ocultar Inventory
    }

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        map = root.Q("Map");
        equipment = root.Q("Equipment");
        // TODO asignar Inventory

        mapArrowL = root.Q("MapArrowL");
        mapArrowR = root.Q("MapArrowR");
        equipmentArrow = root.Q("EquipmentArrow");
        // TODO assignar flecha Inventory

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
            // TODO hacer que se cambie a Inventory
        });

        mapArrowL.RegisterCallback<MouseEnterEvent>(evt =>{
            mapArrowL.style.unityBackgroundImageTintColor = Color.gray;
        });

        mapArrowL.RegisterCallback<MouseLeaveEvent>(evt =>{
            mapArrowL.style.unityBackgroundImageTintColor = Color.white;

        });

        // * INVENTORY ARROW

        // TODO hacer logica de flecha de Inventory

        HideContent();
        equipment.style.display = DisplayStyle.Flex;

    }
}
