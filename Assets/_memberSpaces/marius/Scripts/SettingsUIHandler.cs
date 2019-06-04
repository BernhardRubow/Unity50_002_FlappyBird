using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUIHandler : MonoBehaviour
{
    public InputField nameField;
    public Slider soundVolumeSlider;
    public Slider musicVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("firstStart") == 0)
        {
            PlayerPrefs.SetFloat("soundVolume", 1.0f);
            PlayerPrefs.SetFloat("musicVolume", 1.0f);
            PlayerPrefs.SetInt("firstStart", 1);
        }

        nameField.text = PlayerPrefs.GetString("name");
        soundVolumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUsernameChanged()
    {
        PlayerPrefs.SetString("name", nameField.text);
    }

    public void OnSoundVolumeChanged()
    {
        PlayerPrefs.SetFloat("soundVolume", soundVolumeSlider.value);
    }

    public void OnMusicVolumeChanged()
    {
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);
    }

}
