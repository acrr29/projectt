using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject menuCanvas;

    void Start()
    {
         menuCanvas.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(!menuCanvas.activeSelf && PauseController.IsGamePaused)
            {
                return;
            }
            menuCanvas.SetActive(!menuCanvas.activeSelf);
            PauseController.SetPasue(menuCanvas.activeSelf);
        }
    }
}
