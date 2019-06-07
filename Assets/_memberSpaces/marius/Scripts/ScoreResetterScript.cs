using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// just here to reset the score on start. used in scene 04_Game
public class ScoreResetterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("currentScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
