using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableObject : MonoBehaviour
{
    [SerializeField]
    private GameObject modelWithoutCut, modelCutted;

    private void Update()
    {
        modelCutted.transform.position = transform.position;
    }

    public void Cortar()
    {
        modelWithoutCut.SetActive(false);
        modelCutted.SetActive(true);
    }
}
