using ItemSystem;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Items/DataBase", fileName = "New Item DataBase")]
public class ItemDataBase : ScriptableObject
{
    [SerializeField] private List<ItemConfig> _items;

    public ItemConfig GetItemConfig (string id)
    {
        foreach (var item in _items)
        {
            if(item.ID == id)
                return item;
        }

        return null;
    }

    public Item GetItem(string id)
    {
        ItemConfig config = GetItemConfig(id);

        if (config != null)
            return config.GetItem();

        return null;
    }
}
