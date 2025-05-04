using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Itemselector : MonoBehaviour
{
    public static Itemselector Instance;
    private VisualElement _root;
    private List<VisualElement> _items;
    static private VisualElement _selectedItem = null;

    private void OnEnable(){
        Singleton();

        UIDocument uidoc = GetComponent<UIDocument>();
        _root = uidoc.rootVisualElement;

        _items = _root.Query(className: "item").ToList();
        unselectItems();
    }

    private void unselectItem(VisualElement item){
        VisualElement select = item.Query(name: "Selection");
        select.RemoveFromClassList("Selected");
        select.AddToClassList("Unselected");
    }
    public void unselectItems(){
        _items.ForEach(item =>{
            unselectItem(item);
        });
    }

    public void selectItem(VisualElement item){
        VisualElement select = item.Query(name: "Selection");
        select.RemoveFromClassList("Unselected");
        select.AddToClassList("Selected");

        VisualElement itemInfo = item.Q("ItemInfo");
        itemInfo.RemoveFromClassList("Visible");
        itemInfo.AddToClassList("Invisible");
    }

    private void selectItems(){
        _items.ForEach(item =>{
            selectItem(item);
        });
    }

    static public string getSelectedItemImage()
    {
        if (_selectedItem == null) return "No";

        ItemInfo item = (ItemInfo)_selectedItem.userData;
        return item.Image;
    }

    public VisualElement getSelectedItem(){
        return _selectedItem;
    }

    public void setSelectedItem(VisualElement el){
        _selectedItem = el;
    }

    private void Singleton(){
        if(Instance == null){
            Instance = this;
        }
        else Destroy(this);
    }

    public void addItem(VisualElement item){
        _items.Add(item);

    }
}
