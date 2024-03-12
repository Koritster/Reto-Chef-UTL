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
    private int index = 0;

    public void Validar()
    {
        Debug.Log(listIngredients[index] == ingredientRecieved.nombreIngrediente);
    }
}
