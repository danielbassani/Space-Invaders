using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData
{
   public float volume;

    public SettingsData(float volume)
    {
        this.volume = volume;
    }
}
