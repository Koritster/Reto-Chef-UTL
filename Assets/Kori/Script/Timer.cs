using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float tiempoTranscurrido, tiempoEnCompletar;
    public static bool pausado;

    // Update is called once per frame
    void Update()
    {
        if (!pausado)
        {
            tiempoTranscurrido += Time.deltaTime;
        }
    }

    public static void Win()
    {
        tiempoEnCompletar = tiempoTranscurrido;
    }
}
