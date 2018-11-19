using System;
using System.Collections;
using System.Collections.Generic;
using nopact.Commons.Analytics;
using nopact.Commons.SceneDirection;
using UnityEngine;

namespace nopact.Game.SceneDirection
{
	public static class DirectionEvents
	{

		public static event Action<IAnalyticsTracker, IDirector> OnInitializeDirection;

		public static void InitializeDirection(IAnalyticsTracker tracker, IDirector director)
		{
			if (OnInitializeDirection != null)
			{
				OnInitializeDirection(tracker, director);
			}
		}
	}
	

}
