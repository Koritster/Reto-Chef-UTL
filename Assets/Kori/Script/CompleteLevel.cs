using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteLevel : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject cp_Joysticks;
    [SerializeField] private GameObject cp_Buttons, c_PauseMenu, c_WinScreen;
    [SerializeField] private Text txt_Title, txt_Time, txt_Description;
    [SerializeField] private Image img_Platillo;

    [Header("Información de campos")]
    [TextArea]
    [SerializeField] private string description;
    [SerializeField] private Sprite platillo;

    private void OnTriggerEnter(Collider other)
    {

        Platillo p = other.GetComponent<Platillo>();
        if(p != null && p.ready)
        {
            Timer.pausado = true;
            
            Debug.Log("Ola");
            cp_Buttons.SetActive(false);
            cp_Joysticks.SetActive(false);
            c_PauseMenu.SetActive(true);
            c_WinScreen.SetActive(true);

            Timer.Win();

            txt_Title.text = other.gameObject.name;
            txt_Time.text = Mathf.Floor(Timer.tiempoEnCompletar) + " s";
            txt_Description.text = description;
            img_Platillo.sprite = platillo;
        }
    }
}
