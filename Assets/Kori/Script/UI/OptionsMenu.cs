using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject cp_Joysticks, cp_Buttons, c_Pause, p_Pause, p_Book, p_Help, p_Win;
    private RecipeBook s_RecipeBook;
    private PlayerMovement p_stop;

    private void Awake()
    {
        p_Pause.SetActive(false);
        p_Win.SetActive(false);
        p_Help.SetActive(false);
        p_Book.SetActive(false);
        c_Pause.SetActive(false);

        s_RecipeBook = GetComponent<RecipeBook>();
        p_stop = GameObject.FindGameObjectWithTag("PlayerMovement").GetComponent<PlayerMovement>();
    }

    public void OpenOptionsMenu()
    {
        Timer.pausado = true;

        p_stop.Detener();

        cp_Buttons.SetActive(false);
        cp_Joysticks.SetActive(false);
        c_Pause.SetActive(true);
        p_Pause.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        Timer.pausado = false;

        p_Pause.SetActive(false);
        c_Pause.SetActive(false);
        cp_Buttons.SetActive(true);
        cp_Joysticks.SetActive(true);
    }

    public void AbrirLibro()
    {
        p_Pause.SetActive(false);
        p_Book.SetActive(true);
    }

    public void CerrarLibro()
    {
        s_RecipeBook.AbrirPagina(0);
        p_Book.SetActive(false);
        p_Pause.SetActive(true);
    }

    public void OpenHelpMenu()
    {
        Timer.pausado = true;

        p_stop.Detener();

        cp_Buttons.SetActive(false);
        cp_Joysticks.SetActive(false);
        
        c_Pause.SetActive(true);
        p_Help.SetActive(true);
    }

    public void CloseHelpMenu()
    {
        Timer.pausado = false;

        c_Pause.SetActive(true);
        p_Help.SetActive(false);

        cp_Buttons.SetActive(true);
        cp_Joysticks.SetActive(true);
    }
}
