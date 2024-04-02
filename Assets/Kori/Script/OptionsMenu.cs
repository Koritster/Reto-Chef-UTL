using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject cp_Joysticks, cp_Buttons, c_Pause, p_Pause, p_Book;
    private RecipeBook s_RecipeBook;

    private void Awake()
    {
        p_Pause.SetActive(false);
        p_Book.SetActive(false);
        c_Pause.SetActive(false);

        s_RecipeBook = GetComponent<RecipeBook>();
    }

    public void OpenOptionsMenu()
    {
        Time.timeScale = 0f;

        cp_Buttons.SetActive(false);
        cp_Joysticks.SetActive(false);
        c_Pause.SetActive(true);
        p_Pause.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        Time.timeScale = 1f;

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
}
