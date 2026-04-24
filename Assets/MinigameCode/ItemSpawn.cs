using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject RightSide;
    public GameObject[] items;
    public float startDelay, repeatRate;

    void Start()
    {
        InvokeRepeating("Spawn", startDelay, repeatRate);
    }

    void Spawn()
    {
        Vector3 pos = new Vector3(
        Random.Range(transform.position.x, RightSide.transform.position.x),
        transform.position.y,
        0
    );

        GameObject Item = Instantiate(items[Random.Range(0, items.Length)], pos, transform.rotation) as GameObject;
        Item.transform.SetParent(GameObject.FindGameObjectWithTag("MiniCanvas").transform, false);
    }
}