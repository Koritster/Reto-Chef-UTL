using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] private GameObject cp_Joysticks, cp_Buttons, c_PauseMenu, c_WinScreen;

    private void OnTriggerEnter(Collider other)
    {
        Platillo p = other.GetComponent<Platillo>();
        if(p != null && p.ready)
        {
            cp_Buttons.SetActive(false);
            cp_Joysticks.SetActive(false);
            c_PauseMenu.SetActive(false);
            c_WinScreen.SetActive(true);
        }
    }
}
