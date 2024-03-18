using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    public string finalBowlIngredientName;
    public List<string> listIngredients = new List<string>();
    public List<GameObject> ingredientsModels = new List<GameObject>();
    public Ingrediente ingredientRecieved;
    public bool ready;
    
    private Ingrediente ingredientBowl;
    private int index = 0;

    private void Awake()
    {
        ingredientBowl = GetComponent<Ingrediente>();
    }

    public bool Validar()
    {
        int i = index;
        if (listIngredients[index] == ingredientRecieved.nombreIngrediente)
        {
            ingredientsModels[index].SetActive(true);
            index++;
        }

        ready = index == listIngredients.Count ? true : false;

        return listIngredients[i] == ingredientRecieved.nombreIngrediente;
    }

    public void Batir()
    {
        ingredientBowl.name = finalBowlIngredientName;
        ingredientsModels[index].SetActive(true);
    }
}
