using System.Collections;
using System.Collections.Generic;
using nopact.Commons.UI.PanelWorks;
using UnityEngine;

public class Main : StandardPanel
{

    public void OnClickPlay()
    {
        config.GetAction("Play").Invoke();
    }
}
