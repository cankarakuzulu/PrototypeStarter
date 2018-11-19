using System.Collections;
using System.Collections.Generic;
using nopact.Commons.UI.PanelWorks;
using UnityEngine;

public class Ingame : StandardPanel
{

  public void OnSuccessDummy()
  {
      config.GetAction("Success").Invoke();
  }

  public void OnFailDummy()
  {
    config.GetAction("Fail").Invoke();
  }

  public void OnPause()
  {
    config.GetAction("Pause").Invoke();
  }
}
