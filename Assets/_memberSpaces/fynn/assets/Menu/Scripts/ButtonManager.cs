using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using nvp.Assets.EventHandling;

public class ButtonManager : NvpAbstractEventHandlerV2
{

    public Text starttext;
    public Text settingstext;

    public void onStartButtonPressed()
    {
        EventController.TriggerEvent(EventIdNorm.Hash("Pietro","onstartbutton"), this, "Hello, World");
        starttext.text = "LOADING...";
        this.gameObject.SetActive(false);
    }

        public void onSettingsButtonPressed()
    {
        EventController.TriggerEvent(EventIdNorm.Hash("Pietro","onsettingsbutton"), this, "Hello, World!");
        settingstext.text = "loading...";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
        
}
