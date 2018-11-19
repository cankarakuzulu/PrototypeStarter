using UnityEngine;
using System.Collections;
using System;

namespace nopact.Commons.SceneDirection.Resources
{
    public interface IResourceProvider
    {
        event Action OnInitializationComplete;
        void Initialize();            
        T Get<T>( string name ) where T : UnityEngine.Object;
    }
}
