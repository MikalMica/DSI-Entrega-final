using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Item
{
    ItemInfo _mInfo;
    VisualElement _mRoot;
    
    Label _mName;
    Label _mDesc;

    public Item(VisualElement root, ItemInfo info){
        _mInfo = info;
        _mRoot = root;

        _mRoot.userData = _mInfo;

        _mName = _mRoot.Q<Label>("ItemName");
        _mDesc = _mRoot.Q<Label>("ItemDesc");

        UpdateUI();

        _mInfo.Cambio += UpdateUI;

        _mRoot.RegisterCallback<ClickEvent>(evt =>{
            Itemselector.Instance.unselectItems();
            if(Itemselector.Instance.getSelectedItem() == _mRoot) Itemselector.Instance.setSelectedItem(null);
            else{ 
                Itemselector.Instance.setSelectedItem(_mRoot);
                Itemselector.Instance.selectItem(_mRoot);}

        });

        _mRoot.RegisterCallback<MouseEnterEvent>(evt =>{
            if(Itemselector.Instance.getSelectedItem() == _mRoot) return;

            VisualElement itemInfo = _mRoot.Q("ItemInfo");
            itemInfo.RemoveFromClassList("Invisible");
            itemInfo.AddToClassList("Visible");
        });

        _mRoot.RegisterCallback<MouseLeaveEvent>(evt =>{
            if(Itemselector.Instance.getSelectedItem() == _mRoot) return;

            VisualElement itemInfo = _mRoot.Q("ItemInfo");
            itemInfo.RemoveFromClassList("Visible");
            itemInfo.AddToClassList("Invisible");
        });
    }

    void UpdateUI(){
        VisualElement image = _mRoot.Q("Image");
        image.AddToClassList(_mInfo.Image);

        _mName.text = _mInfo.Name;
        _mDesc.text = _mInfo.Info;
    }

    public string getImageName(){
        return _mInfo.Image;
    }
}
