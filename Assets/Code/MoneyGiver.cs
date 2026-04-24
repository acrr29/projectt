using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoneyGiver : MonoBehaviour, IInteractable
{
    public bool IsOpened { get; private set; }
    [SerializeField] private GameObject miniGameUI;
    [SerializeField] private PlayerInput playerControls;
    private bool playingMiniGame;
    private bool wonMinigame;
    public Sprite openedSprite;

    [Header("References")]
    public GameManager gameManager;

    void Awake()
    {
        miniGameUI.SetActive(false);
        playingMiniGame = false;
        wonMinigame = false;
    }

    void Update()
    {
        if(playingMiniGame)
        {
            playerControls.DeactivateInput();
        }
        else if (!playingMiniGame)
        {
            playerControls.ActivateInput();
        }

        if (wonMinigame && Input.GetKeyDown(KeyCode.E))
        {
            miniGameUI.SetActive(false);
            playingMiniGame = false;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            OpenMinigame();
        }
    }

    private void OpenMinigame()
    {
        miniGameUI.SetActive(true);
        playingMiniGame = true;
    }

    public void EndMinigame()
    {
        miniGameUI.SetActive(false);
        playingMiniGame = false;
        wonMinigame = true;
    }


    public bool CanInteract()
    {
        return !IsOpened; //if its closed you can interact. If you won the game then you cant interact.
    }

    public void Interact()
    {
        if (!CanInteract() ) return; //if you can't interact 
        OpenMoneyGiver();

    }

    private void OpenMoneyGiver()
    {
        SetOpened(true);
        gameManager.AddCollectible();
    }

    private void SetOpened(bool opened)
    {
        if(IsOpened = opened)
        {
            GetComponent<SpriteRenderer>().sprite = openedSprite;
        }
    }
    
}
