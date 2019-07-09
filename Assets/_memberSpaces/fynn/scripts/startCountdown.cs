using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class startCountdown : MonoBehaviour
{

    public TextMeshProUGUI startCountdownText;

    // Start is called before the first frame update
    void Start()
    {
        startCountdownText.text = "3";
        StartCoroutine( playStartCountdown());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator playStartCountdown()
    {
        for (int f = 3; f >= 0; f--)
        {
            yield return new WaitForSeconds(0.33f);
            startCountdownText.text = f.ToString();
        }
        startCountdownText.text = "";
    } 
}