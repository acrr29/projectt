using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public int collectibleCount = 0;
    public TMP_Text collectibleText;

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
        collectibleText.text = $"Collectibles: {collectibleCount}";
    }

    public void AddCollectible()
    {
        collectibleCount++;
        UpdateCollectibleUI();
    }

    public void UpdateCollectibleUI()
    {
        collectibleText.text = $"Collectibles: {collectibleCount}";
    }
}
