using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDictionary : MonoBehaviour
{
    public List<Item> itemsPrefabs;
    private Dictionary<int, GameObject> itemDictionary;

    private void Awake()
    {
        itemDictionary = new Dictionary<int, GameObject>();

        for(int i = 0; i < itemsPrefabs.Count; i++)
        {
            if(itemsPrefabs[i] != null)
            {
                itemsPrefabs[i].ID = i +1;
            }
        }

        foreach (Item item in itemsPrefabs)
        {
            itemDictionary[item.ID] = item.gameObject;
        }
    }

    public GameObject GetItemPrefab(int id)
    {
       itemDictionary.TryGetValue(id, out GameObject Prefab);
       if(Prefab == null)
       {
           Debug.LogError($"Item with ID {id} not found in the dictionary.");
       }
       return Prefab;
    }
}