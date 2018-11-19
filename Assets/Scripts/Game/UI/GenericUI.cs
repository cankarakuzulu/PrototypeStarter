using System;
using System.Collections;
using System.Collections.Generic;
using nopact.Commons.Analytics;
using nopact.Commons.SceneDirection;
using nopact.Commons.UI.PanelWorks;
using nopact.Commons.UI.PanelWorks.Localization;
using nopact.Game.SceneDirection;
using UnityEngine;

public class GenericUI : MonoBehaviour
{

    [SerializeField] protected GameUI uiProvider;
    
    private IAnalyticsTracker analytics;
    private DirectorBase director;
    private ILocalizationProvider localization;
    
    private void OnInitializeUI()
    {
        Main = uiProvider.GetPanel<Main>("Main");
        Endgame = uiProvider.GetPanel<Endgame>("Endgame");
        Ingame = uiProvider.GetPanel<Ingame>("Ingame");
        Main.Setup( new UIPanelParameter ( localization) { ActionCallbacks = new Dictionary<string, Action> {{ "Play",  OnPlayCommand}}});
        Endgame.Setup( new UIPanelParameter(localization) { ActionCallbacks =  new Dictionary<string, Action>{{ "Retry", OnRetry }, {"Next", OnNext}}});
        Ingame.Setup( new UIPanelParameter( localization ) { ActionCallbacks = new Dictionary<string, Action> { {"Pause", OnPause},{"Success", ()=>OnIngameUIResult(true)}, { "Fail", ()=> OnIngameUIResult(false)}}});
        Main.Open();
    }

    
    private void OnEnable()
    {
        DirectionEvents.OnInitializeDirection += DirectionEventsOnOnInitializeDirection;
    }

    private void OnDisable()
    {
        DirectionEvents.OnInitializeDirection -= DirectionEventsOnOnInitializeDirection;
    }

    #region UICallbacks

    private void OnNext()
    {
        Endgame.Close();
        director.UiNextCommand();
        Ingame.Open();
    }

    private void OnRetry()
    {
        Endgame.Close();
        director.UiRetryCommand();
        Ingame.Open();
    }

    private void OnPlayCommand()
    {
        Main.Close();
        director.UiPlayCommand();
        Ingame.Open();
    }
    
    private void OnIngameUIResult(bool isSuccessful)
    {
        Ingame.Close();
        director.UiIngameStateUpdate( isSuccessful );
        var result = new ResultParams("Level 2-3", isSuccessful ? "Success" : "Failed", "High score: 3500", "2000",
            isSuccessful, false);
        Endgame.SetResult(result);
        Endgame.Open();
    }

    private void OnPause()
    {
        director.UiPauseCommand();
    }

    #endregion
    
    #region EventHandlers
    private void DirectionEventsOnOnInitializeDirection(IAnalyticsTracker analytics, IDirector director)
    {
        this.director = director as DirectorBase;
        if (this.director == null)
        {
            Debug.LogWarning("<color=yellow>[GenericUI] You cannot use this type of IDirector with Generic UI.</color>");
            return;
        }
        this.analytics = analytics;
        OnInitializeUI();
    }
    #endregion
    
    #region UIPanelEncapsulation

    private Main Main { get; set; }
    private Endgame Endgame { get; set; }
    private Ingame Ingame { get; set; }
    
    #endregion
}
