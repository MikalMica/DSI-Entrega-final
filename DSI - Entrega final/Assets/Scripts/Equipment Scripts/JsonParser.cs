using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonParser : MonoBehaviour
{
    [Serializable]
    private class ItemList<ItemInfo>{

        public List<ItemInfo> list;

    }

    public static List<ItemInfo> FromJson<ItemInfo>(string json){
        ItemList<ItemInfo> itemList = JsonUtility.FromJson<ItemList<ItemInfo>>(json);
        return itemList.list;
    }

    public static string ToJson<ItemInfo>(List<ItemInfo> items){
        ItemList<ItemInfo> itemList = new ItemList<ItemInfo>();
        itemList.list = items;
        return JsonUtility.ToJson(itemList);
    }

    public static string ToJson<ItemInfo>(List<ItemInfo> items, bool prettyPrint){
        ItemList<ItemInfo> itemList = new ItemList<ItemInfo>();
        itemList.list = items;
        return JsonUtility.ToJson(itemList, prettyPrint);
    }
}
