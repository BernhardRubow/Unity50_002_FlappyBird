using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class SettingsManagerScript : MonoBehaviour
{
    private string playerNameRegex = @"([^A-Za-z0-9_])+";

    private string removeCharByIndex(string text, int index)
    {
        string firstPart = text.Substring(0, index);
        string secondPart = text.Substring(index + 1, text.Length - (index + 1));
        string ret = firstPart + secondPart;
        return ret;
    }

    private bool contains(string text, char chr)
    {
        for (int i = 0; i < text.Length; i++)
            if (text[i] == chr)
                return true;
        return false;
    }

    private bool contains(char chr, string text)
    {
        return contains(text, chr);
    }

    private string adjustPlayerName(string text) {
        string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_";

        for (int i = 0; i < text.Length; i++)
        {
            if (contains(text[i], allowedChars) == false) // if the current char is none / contains none of the allowed chars
                text = removeCharByIndex(text, i);
        }

        return text;
    }

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
            PlayerPrefs.SetString("name", "");
            PlayerPrefs.SetInt("firstStart", 1);
        }

    }

    // we only have to do this for the score system at the highscore list
    // fixedupdate instead of update to prevent lag
    void FixedUpdate()
    {
        // 7 digits is maximum at the highscores list
        if (PlayerPrefs.GetInt("currentScore") > 9999999)
            PlayerPrefs.SetInt("currentScore", 9999999);

        // playerNameRegex is a negative regex. that means that the regex is only true if there are some chars that DO NOT MATCH the allowed chars specified in playerNameRegex
        if (Regex.IsMatch(PlayerPrefs.GetString("name"), playerNameRegex) == true) {
            PlayerPrefs.SetString(
                "name",
                adjustPlayerName(PlayerPrefs.GetString("name"))
                );
        }
        
    }
}
