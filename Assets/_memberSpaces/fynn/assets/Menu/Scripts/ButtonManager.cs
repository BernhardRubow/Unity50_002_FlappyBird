using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using nvp.Assets.EventHandling;

public class ButtonManager : NvpAbstractEventHandlerV2
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public Text starttext;
    public Text settingstext;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    protected override void Start()
    {
        base.Start();
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void onStartButtonPressed()
    {
        EventController.TriggerEvent(
            EventIdNorm.Hash("Pietro","onstartbutton"), 
            this, 
            "Hello, World");
        starttext.text = "LOADING...";
        this.gameObject.SetActive(false);
    }

    public void onSettingsButtonPressed()
    {
        EventController.TriggerEvent(
            EventIdNorm.Hash("Pietro","onsettingsbutton"), 
            this, 
            "Hello, World!");
        settingstext.text = "loading...";
    }

    void onResetLoadingTexts(object sender, object data)
    {
        starttext.text = "START";
        settingstext.text = "settings";
    }




    // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    protected override void StartListenToEvents()
    {
        EventController.StartListenForEvent(
            EventIdNorm.Hash("marius", "backToMenu"),
            onResetLoadingTexts);
    }

    protected override void StopListenToEvents()
    {
        EventController.StopListenForEvent(
            EventIdNorm.Hash("marius", "backToMenu"),
            onResetLoadingTexts);
    }

}
