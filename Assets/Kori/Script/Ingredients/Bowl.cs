using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bowl : MonoBehaviour
{
    #region Bowl - Variables

    [Header("Variables Bowl")]
    public string finalBowlIngredientName;
    public List<string> listIngredients = new List<string>();
    public List<GameObject> ingredientsModels = new List<GameObject>();
    public Ingrediente ingredientRecieved;
    public bool ready;

    private Ingrediente ingredientBowl;
    private int index = 0;

    #endregion

    #region Feedback - Variables

    [Space(10)]
    [Header("Feedback")]
    [SerializeField] private GameObject cf_text;
    [SerializeField] private Color cf_CorrectColor, cf_IncorrectColor;
    public GameObject iconReady;

    [Header("Progreso")]
    [SerializeField] private Image img_ProgressBar;
    [SerializeField] private Text txt_NextIngredient;


    #endregion

    private void Awake()
    {
        ChangeProgressBar();
        ChangeNextIngredient(ready, index);

        ingredientBowl = GetComponent<Ingrediente>();
    }

    #region Bowl - Funciones

    public bool Validar()
    {
        int i = index;
        Debug.Log(index);
        if (listIngredients[index] == ingredientRecieved.nombreIngrediente)
        {
            ingredientsModels[index].SetActive(true);
            index++;

            ActivateTextAnimation("Se ha agregado " + ingredientRecieved.nombreIngrediente, cf_CorrectColor);

            ChangeProgressBar();

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

        ChangeNextIngredient(ready, index);

        return listIngredients[i] == ingredientRecieved.nombreIngrediente;
    }

    public void Batir()
    {
        ingredientBowl.nombreIngrediente = finalBowlIngredientName;
        ingredientsModels[index].SetActive(true);
    }

    public void Vaciar()
    {
        index = 0;
        foreach(GameObject i in ingredientsModels)
        {
            i.SetActive(false);
        }
        ready = false;
        ingredientBowl.nombreIngrediente = "Bowl";

        iconReady.SetActive(false);
    }

    #endregion

    #region Feedback - Funciones

    private void ActivateTextAnimation(string text, Color color)
    {
        cf_text.GetComponent<Text>().text = text;
        cf_text.GetComponent<Text>().color = color;
        cf_text.GetComponent<Animator>().Play("Feedback");
        StartCoroutine(waitForFeedbackAnimation());
    }

    private void ChangeProgressBar()
    {
        img_ProgressBar.fillAmount = index / ingredientsModels.Count;
    }

    private void ChangeNextIngredient(bool r, int i)
    {
        if (r)
        {
            txt_NextIngredient.text = "Batir";
        }
        else
        {
            i++;
            txt_NextIngredient.text = listIngredients[i];
        }
    }

    IEnumerator waitForFeedbackAnimation()
    {
        yield return new WaitForSeconds(1f);
        cf_text.GetComponent<Animator>().Play("New State");
    }

    #endregion
}
