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

    void OnEnable()
    {
        UIDocument uidoc = GetComponent<UIDocument>();
        _root = uidoc.rootVisualElement;

        _squares = _root.Query(className: "container").ToList();

        _squares.ForEach(container =>{
            ItemInfo info = new ItemInfo("", "", _default);
            Square square = new Square(container.Q("Item"), info);

            container.RegisterCallback<MouseDownEvent, ItemInfo>(ChangeImage, info);
        });
    }

    void ChangeImage(MouseDownEvent evt, ItemInfo info){
        if(Itemselector.getSelectedItemImage() == null) info.Image = _default;
        else info.Image = Itemselector.getSelectedItemImage();
    }
}
