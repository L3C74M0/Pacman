using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfSound : MonoBehaviour {

    public Slider slider;
    public float sliderValue;

    void Start() {
        slider.value = PlayerPrefs.GetFloat("volume", 0.5f);
        AudioListener.volume = slider.value;
    }

    public void ChangeSlider(float value) {
        sliderValue = value;
        PlayerPrefs.SetFloat("volume", sliderValue);
        AudioListener.volume = slider.value;
    }
}