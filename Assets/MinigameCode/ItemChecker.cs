using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemChecker : MonoBehaviour
{
    public int minigameScore;
    public GameObject scoreTextObject;
    private TMP_Text tmpText;

    [Header("References")]
    public MoneyGiver moneyGiver;
    public GameManager gameManager;

    void Start()
    {

        tmpText = scoreTextObject.GetComponent<TMP_Text>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
  
        if (other.gameObject.tag == "Good")
        {
            minigameScore += 1;
            Destroy(other.gameObject);
        }

  
        if (other.gameObject.tag == "Bad")
        {
            minigameScore -= 1;
            Destroy(other.gameObject);
        }

        tmpText.text = minigameScore.ToString();
    }

    public void Update()
    {
        if (minigameScore == 5)
        {
            moneyGiver.EndMinigame();
        }
    }
}
