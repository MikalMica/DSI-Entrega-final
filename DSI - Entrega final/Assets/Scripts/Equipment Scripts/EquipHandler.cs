using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EquipHandler : MonoBehaviour
{
    VisualElement _root;
    List<VisualElement> _squares;

    string _default = "No";
    List<string> _equipped = new List<string>();

    void OnEnable()
    {
        UIDocument uidoc = GetComponent<UIDocument>();
        _root = uidoc.rootVisualElement;

        _squares = _root.Query(className: "container").ToList();

        _squares.ForEach(container =>{
            ItemInfo info = new ItemInfo("", "", _default);
            Square square = new Square(container.Q("Item"), info);

            container.RegisterCallback<MouseDownEvent, ItemInfo>(TryChangeImage, info);
        });
    }

    void TryChangeImage(MouseDownEvent evt, ItemInfo info){
        if(!_equipped.Contains(Itemselector.getSelectedItemImage()) && Itemselector.getSelectedItemImage() != "No"){

            _equipped.Remove(info.Image);
            info.Image = Itemselector.getSelectedItemImage();
            _equipped.Add(info.Image);
        }
        else if(Itemselector.getSelectedItemImage() == "No"){

            _equipped.Remove(info.Image);
            info.Image = Itemselector.getSelectedItemImage();
        }
    }
}
