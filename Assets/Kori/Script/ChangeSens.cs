using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSens : MonoBehaviour
{
    [SerializeField] private Slider sl_sens;
    [SerializeField] private TextMeshProUGUI txt_sens;

    // Start is called before the first frame update
    void Start()
    {
        float s = PlayerPrefs.GetFloat("sens", 20);
        sl_sens.value = s;
        txt_sens.text = "" + s;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSensi()
    {
        PlayerPrefs.SetFloat("sens", sl_sens.value);
        txt_sens.text = "" + sl_sens.value;
    }
}
