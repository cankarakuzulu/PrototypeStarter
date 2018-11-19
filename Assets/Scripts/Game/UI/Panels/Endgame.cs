using System.Collections;
using System.Collections.Generic;
using nopact.Commons.UI.PanelWorks;
using UnityEngine;
using UnityEngine.UI;

public class Endgame : StandardPanel
{

    [SerializeField] protected Text score, highscore, resultTxt, levelTxt;
    [SerializeField] protected GameObject retryButton, nextButton;
    
    public void SetResult(ResultParams result)
    {
        nextButton.SetActive( result.IsSuccessful );
        resultTxt.text = result.ResultString;
        levelTxt.text = result.LevelString;
        score.text = result.ScoreString;
        highscore.text = result.HighscoreString;
    }
    
    public void OnClickRetry()
    {
        config.GetAction("Retry").Invoke();
    }

    public void OnClickNext()
    {
        config.GetAction("Next").Invoke();
    }

}