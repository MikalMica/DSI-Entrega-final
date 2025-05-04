using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemSpawner : MonoBehaviour
{
    VisualElement SpawnButton;
    VisualElement ItemContainer;

    string[,] itemList = {{"Espada del caos", "Espada dura de cojones", "Espadas"}, {"Dagas Eclipse", "De día y noche", "Dagas"}, {"Arco fenix", "Resurrecion't", "Arco"}, {"Casco protector", "Ni el de minecraft", "Casco"}, 
                           {"Varita de Jotunn", "Varota mas bien...", "Varita"}, {"Daga rasgamundos", "También rasga cuellos", "Daga"}, {"Capalma", "Pa el frío del infierno", "Capa"}};

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        SpawnButton = root.Q("SpawnButton");
        ItemContainer = root.Q("EquipmentItems");

        SpawnButton.RegisterCallback<ClickEvent>(AddItem);
    }

    void AddItem(ClickEvent evt){

        VisualTreeAsset template = Resources.Load<VisualTreeAsset>("Item");
        VisualElement item = template.Instantiate().Q("Item");

        ItemContainer.Add(item);

        ItemInfo info = getRandomItemInfo();
        Item aItem = new Item(item, info);

        Itemselector.Instance.addItem(item);
    }

    ItemInfo getRandomItemInfo(){
        int rndNmbr = Random.Range(0, 7);

        ItemInfo info = new ItemInfo(itemList[rndNmbr, 0], itemList[rndNmbr, 1], itemList[rndNmbr, 2]);

        return info;
    }
}
