using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Itemselector : MonoBehaviour
{
    private VisualElement _root;
    private List<VisualElement> _items;
    static private Item _selectedItem = null;

    private void OnEnable(){
        UIDocument uidoc = GetComponent<UIDocument>();
        _root = uidoc.rootVisualElement;

        _items = _root.Query(className: "item").ToList();
        unselectItems();

        _items.ForEach(item =>{
            item.RegisterCallback<ClickEvent>(evt =>{
                unselectItems();
                if(_selectedItem == item) _selectedItem = null;
                else{ 
                    _selectedItem = item;
                    selectItem(item);}

            });
        });
    }

    private void unselectItem(VisualElement item){
        VisualElement select = item.Query(name: "Selection");
        select.RemoveFromClassList("Selected");
        select.AddToClassList("Unselected");
    }
    private void unselectItems(){
        _items.ForEach(item =>{
            unselectItem(item);
        });
    }

    private void selectItem(VisualElement item){
        VisualElement select = item.Query(name: "Selection");
        select.RemoveFromClassList("Unselected");
        select.AddToClassList("Selected");
    }

    private void selectItems(){
        _items.ForEach(item =>{
            selectItem(item);
        });
    }

    static public string getSelectedItemImage()
    {
        if (_selectedItem == null) return "No";
        else return _selectedItem.;
    }
}
