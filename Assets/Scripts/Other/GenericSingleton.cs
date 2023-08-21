using UnityEngine;

namespace SimpleShooty.GenericSingleton
{
    public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
    {
        public static T Instance { get; private set; }

        protected void Awake()
        {
            if(Instance == null)
            {
                Instance = (T)this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}