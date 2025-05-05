using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class ItemStorer : MonoBehaviour
{
    static public ItemStorer Instance;

    List<ItemInfo> _items = new List<ItemInfo>();

    void OnEnable()
    {
        Singleton();

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement saveButton = root.Q("SaveButton");
        VisualElement loadButton = root.Q("LoadButton");

        saveButton.RegisterCallback<ClickEvent>(SaveToJson);
        loadButton.RegisterCallback<ClickEvent>(LoadFromJson);
    }

    void Singleton(){
        if(Instance == null) Instance = this;
        else Destroy(this);
    }

    public void AddItem(ItemInfo item){
        _items.Add(item);
    }

    public void SaveToJson(ClickEvent evt){
        string json = JsonParser.ToJson<ItemInfo>(_items, true);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Individuos.json", json);
    }

    public void LoadFromJson(ClickEvent evt){
        string json = System.IO.File.ReadAllText(Application.persistentDataPath + "/Individuos.json");
        if(json == null) return;
        _items = JsonParser.FromJson<ItemInfo>(json);

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement ItemContainer = root.Q("EquipmentItems");

        foreach(var item in _items){
            VisualTreeAsset template = Resources.Load<VisualTreeAsset>("Item");
            VisualElement itemObject = template.Instantiate().Q("Item");

            ItemContainer.Add(itemObject);

            Item aItem = new Item(itemObject, item);

            Itemselector.Instance.addItem(itemObject);
        }
    }

}
