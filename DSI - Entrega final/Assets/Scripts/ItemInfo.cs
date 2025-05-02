using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemInfo : MonoBehaviour
{
    public event Action Cambio;
    public event Action preCambio;

    private string _image;
    public string Image{
        get{return _image;}
        set{
            preCambio?.Invoke();
            _image = value;
            Cambio?.Invoke();
        }
    }

    private string _info;
    public string Info{
        get{return _info;}
        set{
            _info = value;
            Cambio?.Invoke();
        }
    }

    private string _name;
    public string Name
    {
        get{return _name;}
        set{
            _name = value;
            Cambio?.Invoke();
        }
    }

    public ItemInfo(string name, string info, string image){
        _image = image;
        _name = name;
        _info = info;
    }
}
