using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManagerScript : MonoBehaviour
{
    void Start()
    {
        // check for any not set variables in the playerprefs the game uses
        // theese are only have to be set on first start but you should include
        // this script / the settingsManager prefab in every scene in case
        // someone clones this repository and directly starts at a specific scene
        // thats not main (in case your game starts at main and you only use this
        // in the main scene). if that occurs the settings won't be set and the
        // game won't work

        if (PlayerPrefs.GetInt("firstStart") == 0)
        {
            PlayerPrefs.SetFloat("soundVolume", 1.0f);
            PlayerPrefs.SetFloat("musicVolume", 1.0f);
            PlayerPrefs.SetInt("firstStart", 1);
        }

    }

    // we dont need to do this every frame
    void Update()
    {
        
    }
}
