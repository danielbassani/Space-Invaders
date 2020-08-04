using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider volumeSlider;
    public GameObject mainMenuUI;
    public float volume;

    private void Start()
    {
        SettingsData data = SaveSystem.LoadSettings();

        if(data != null)
        {
            volumeSlider.value = data.volume;
            volume = data.volume;
        }
        else
        {
            volumeSlider.value = 1f;
        }
        
    }

    public void SetVolume()
    {
        volume = volumeSlider.value;
    }

    public void Back()
    {
        SaveSystem.SaveSettings(volume);
        this.gameObject.SetActive(false);
        mainMenuUI.SetActive(true);
    }
}
