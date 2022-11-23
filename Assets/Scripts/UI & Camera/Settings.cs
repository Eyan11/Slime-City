using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;

    void Start() {
        if(!PlayerPrefs.HasKey("GameVolume")) {
            PlayerPrefs.SetFloat("GameVolume", 0.5f);
            Load();
        }
        else {
            Load();
        }
    } 

    public void ChangeVolume() {
        AudioListener.volume = volumeSlider.value;
    }

    private void Load() {
        volumeSlider.value = PlayerPrefs.GetFloat("GameVolume");
    }

    private void Save() {
        PlayerPrefs.SetFloat("GameVolume", volumeSlider.value);
    }
}
