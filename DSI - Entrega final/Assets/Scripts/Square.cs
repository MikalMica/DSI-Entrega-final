using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class Square : MonoBehaviour
{
    ItemInfo _mInfo;
    VisualElement _mRoot;
    VisualElement _mImageSquare;

    public Square(VisualElement root, ItemInfo info){
        _mInfo = info;
        _mRoot = root;

        _mImageSquare = _mRoot.Q("Item");
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
}
