using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]

//can be damaged with IDamageable
public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float invulnerabillityDuration = 1f;
    [SerializeField] float blinkInterval = 0.1f;

    float currentHealth;

    float invulnerabillityTimer;

    SpriteRenderer sprite;

    float blinkTimer;

    bool blinking;

// VOID AWAKE SETS UP BEFORE VOID STSRT
    void Awake()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
    }

//updates every frame
    void Update()
    {
        if(invulnerabillityTimer > 0f)
        {
            invulnerabillityTimer-=Time.deltaTime; //the frame rate of the game and this does a countdown
            HandleBlink();
        }
    }

    public bool ApplyDamage(float amount)
    {
        if(currentHealth<=0f || invulnerabillityTimer > 0f)
        return false;

        currentHealth -= amount;
        if(currentHealth <= 0f)
        {
            Die();
            return true;
        }
        invulnerabillityTimer = invulnerabillityDuration;
        StartBlink(invulnerabillityDuration);
        return true;
    }

void StartBlink(float duration)
{
    blinking = true;
    blinkTimer = duration;
}

void HandleBlink()
{
    if(!blinking)
    { 
        return;
    }

    blinkTimer -= Time.deltaTime;

    if(blinkTimer <= 0f)
    {
        blinking = false;
        sprite.enabled = true;
        return;
    }
    sprite.enabled =
    Mathf.FloorToInt(blinkTimer/blinkInterval) % 2 == 0;
}

void Die()
{
    gameObject.SetActive(false);
}
}
