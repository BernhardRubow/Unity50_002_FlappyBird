using Assets._memberSpaces.nvp.Scripts._AbstractBaseClasses;
using nvp.Scripts.Tools.Events;

public class SceneController_Prototyp_Oncoming_Pillars : AbstractEventHandler
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    



    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Awake()
    {
        SubscribeToEvents();
    }

    void Start()
    {
        EventController.InvokeEvent(NvpGameEvents.OnDebugMsg, this, "Hello, World!");
    }

    
    void Update()
    {
        
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    protected override void OnDisable()
    {
        base.OnDisable();
        UnsubscribeFromEvents();
    }




    // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    protected override void SubscribeToEvents()
    {
        
    }

    protected override void UnsubscribeFromEvents()
    {
        
    }
}
