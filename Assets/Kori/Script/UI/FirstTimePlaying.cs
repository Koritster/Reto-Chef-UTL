using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimePlaying : MonoBehaviour
{
    private OptionsMenu scrp_OptionsMenu;
    private int primeraVez;

    private void Start()
    {
        scrp_OptionsMenu = GetComponent<OptionsMenu>();
        primeraVez = PlayerPrefs.GetInt("PrimeraVez", 0);
        Debug.Log("Es la primera vez que el jugador entra? " + primeraVez);

        if (primeraVez == 0)
        {
            scrp_OptionsMenu.OpenFirstTimePanel();
        }

        PlayerPrefs.SetInt("PrimeraVez", 1);
    }
}
