using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //se puede cambiar por el nombre de la scene en el parentesis
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
