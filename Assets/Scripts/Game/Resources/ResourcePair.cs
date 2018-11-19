using System;
using System.Collections.Generic;
using UnityEngine;

namespace nopact.Game.Resources
{
    [Serializable]
    public class ResourcePair
    {
        

        [SerializeField] protected string name;
        [SerializeField] protected GameObject gameObject;
        [SerializeField] protected bool isPooled;
        [SerializeField] protected ushort poolMax;
        [SerializeField] protected ushort poolMin;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public GameObject GameObject
        {
            get
            {
                return gameObject;
            }
        }

        public bool IsPooled
        {
            get
            {
                return isPooled;
            }
        }

        public ushort PoolMin
        {
            get
            {
                return poolMin;
            }
        }

        public ushort PoolMax
        {
            get
            {
                return poolMax;
            }
        }

        public static IComparer<ResourcePair>Comparer
        {
            get
            {
                return new PairComparer();
            }
        }

        public class PairComparer : IComparer<ResourcePair>
        {
            public int Compare( ResourcePair x, ResourcePair y )
            {
                return string.Compare( x.name, y.name );
            }
        }
    }
    
}
