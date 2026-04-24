using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroyer : MonoBehaviour
{
    public float aliveTimer = 5f;

    void Start()
    {
        Destroy(gameObject, aliveTimer);
    }
}
