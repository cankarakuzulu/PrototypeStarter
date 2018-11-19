using nopact.Commons.Analytics;
using nopact.Commons.Input;
using nopact.Commons.Persistence;
using nopact.Commons.SceneDirection;
using nopact.Commons.SceneDirection.PlaySession;
using nopact.Commons.SceneDirection.Resources;
using UnityEngine;

namespace nopact.Game.SceneDirection
{
    public class DirectorBase : MonoBehaviour, IDirector
    {

        private ISceneLoader loader;
        private IResourceProvider resources;
        private IAnalyticsTracker analytics;
        
        public void Initialize(ISceneLoader loader, IResourceProvider resourceProvider, IAnalyticsTracker analyticsTracker)
        {
            this.loader = loader;
            resources = resourceProvider;
            analytics = analyticsTracker;
            DirectionEvents.InitializeDirection( analyticsTracker, this );
        }

        public void RegisterCameraPosition(Transform t, string id)
        {
            
        }

        public void Kill()
        {
            
        }

        public void OnControlUpdate<T>(T inputState) where T : InputStateBase
        {
            
        }

        public void UiIngameStateUpdate(bool isSuccessful)
        {
            
        }

        public void UiPauseCommand()
        {
            
        }

        public void UiPlayCommand()
        {
            
        }

        public void UiNextCommand()
        {
            
        }

        public void UiRetryCommand()
        {
            
        }

        public PlaySessionBase PlaySession { get; private set; }
    }
}