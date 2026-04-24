using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public int collectibleCount = 0;
    public TMP_Text collectibleText;
    public GameObject door;
    public GameObject blue;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        collectibleText.text = $"€ {collectibleCount} mil";
    }

    public void AddCollectible()
    {
        collectibleCount+= 5;
        UpdateCollectibleUI();
    }

    public void UpdateCollectibleUI()
    {
        collectibleText.text = $"€ {collectibleCount} mil";

        if(collectibleCount == 20)
        {
            Destroy(door);
        }
    
    }
}
