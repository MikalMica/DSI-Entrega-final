using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Item : MonoBehaviour
{
    ItemInfo _mInfo;
    VisualElement _mRoot;
    // TODO Hacer elementos de Items;

    public Item(VisualElement root, ItemInfo info){
        _mInfo = info;
        _mRoot = root;

        _mRoot.userData = _mInfo;

        UpdateUI();

        _mInfo.Cambio += UpdateUI;
        _mInfo.preCambio += RemoveCurrentImage;
    }

    void UpdateUI(){
        _mImageSquare.AddToClassList(_mInfo.Image);
    }

    void RemoveCurrentImage(){
        _mImageSquare.RemoveFromClassList(_mInfo.Image);
    }

    string getImageName(){
        return _mInfo.Image;
    }
}
