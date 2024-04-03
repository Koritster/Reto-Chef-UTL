using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetOptionFromUI : MonoBehaviour
{
    public Scrollbar volumeSlider;
    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetGlobalVolume);
    }

    public void SetGlobalVolume(float value)
    {
        AudioListener.volume = value;
    }
}
