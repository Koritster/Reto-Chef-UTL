using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float tiempoTranscurrido, tiempoEnCompletar;
    public static bool pausado;
    [SerializeField] private Text txt_Timer;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(tiempoTranscurrido);
        if (!pausado)
        {
            tiempoTranscurrido += Time.deltaTime;
            float f = Mathf.Round(tiempoTranscurrido * 100) * 0.01f;
            txt_Timer.text = f.ToString();
        }
    }

    public static void Win()
    {
        tiempoEnCompletar = tiempoTranscurrido;
    }
}
