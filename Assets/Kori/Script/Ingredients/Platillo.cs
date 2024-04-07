using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Platillo : MonoBehaviour
{
    #region Bowl - Variables

    [Header("Variables Bowl")]
    public List<string> listIngredients = new List<string>();
    public List<GameObject> ingredientsModels = new List<GameObject>();
    public Ingrediente ingredientRecieved;
    public bool ready;

    private int index = 0;

    #endregion

    #region Feedback - Variables

    [Space(10)]
    [Header("Feedback")]
    [SerializeField] private GameObject cf_text;
    [SerializeField] private Color cf_CorrectColor, cf_IncorrectColor;
    public GameObject iconReady;

    #endregion

    public bool Validar()
    {
        int i = index;
        if (listIngredients[index] == ingredientRecieved.nombreIngrediente)
        {
            ingredientsModels[index].SetActive(true);
            index++;

            ActivateTextAnimation("Se ha agregado " + ingredientRecieved.nombreIngrediente, cf_CorrectColor);

            if (ingredientRecieved.gameObject.GetComponent<Bowl>())
            {
                ingredientRecieved.gameObject.GetComponent<Bowl>().Vaciar();
            }
        }
        else
        {
            ActivateTextAnimation("Ingrediente incorrecto", cf_IncorrectColor);
        }

        ready = index == listIngredients.Count ? true : false;
        iconReady.SetActive(ready);

        return listIngredients[i] == ingredientRecieved.nombreIngrediente;
    }

    #region Feedback - Funciones

    private void ActivateTextAnimation(string text, Color color)
    {
        cf_text.GetComponent<Text>().text = text;
        cf_text.GetComponent<Text>().color = color;
        cf_text.GetComponent<Animator>().Play("Feedback");
        StartCoroutine(waitForFeedbackAnimation());
    }

    IEnumerator waitForFeedbackAnimation()
    {
        yield return new WaitForSeconds(1f);
        cf_text.GetComponent<Animator>().Play("New State");
    }

    #endregion
}
