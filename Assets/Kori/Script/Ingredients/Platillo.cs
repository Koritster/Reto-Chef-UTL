using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Platillo : MonoBehaviour
{
    public List<string> listIngredients = new List<string>();
    public List<GameObject> ingredientsModels = new List<GameObject>();
    public Ingrediente ingredientRecieved;
    public bool ready;
    
    private int index = 0;


    public bool Validar()
    {
        int i = index;
        if(listIngredients[index] == ingredientRecieved.nombreIngrediente)
        {
            ingredientsModels[index].SetActive(true);
            index++;
        }

        if (ingredientRecieved.gameObject.GetComponent<Bowl>())
        {
            ingredientRecieved.gameObject.GetComponent<Bowl>().Vaciar();
        }

        ready = index == listIngredients.Count ? true : false;

        return listIngredients[i] == ingredientRecieved.nombreIngrediente;
    }
}
