using JetBrains.Annotations;
using UnityEngine;

// https://gamedev.stackexchange.com/questions/116009/in-unity-how-do-i-correctly-implement-the-singleton-pattern

namespace Utils
{
    public abstract class Singleton<T> : Singleton where T : MonoBehaviour
    {
        [NotNull]
        public static T Instance
        {
            get
            {
                if (Quitting)
                {
                    Debug.LogWarning(
                        $"[{nameof(Singleton)}<{typeof(T)}>] Instance will not be returned because the application is quitting.");
                    // ReSharper disable once AssignNullToNotNullAttribute
                    return null;
                }

                lock (Lock)
                {
                    if (instance != null)
                        return instance;
                    var instances = FindObjectsOfType<T>(true);
                    var count = instances.Length;
                    if (count > 0)
                    {
                        if (count == 1)
                            return instance = instances[0];
                        Debug.LogWarning(
                            $"[{nameof(Singleton)}<{typeof(T)}>] There should never be more than one {nameof(Singleton)} of type {typeof(T)} in the scene, but {count} were found. The first instance found will be used, and all others will be destroyed.");
                        for (var i = 0; i < instances.Length - 1; i++)
                            Destroy(instances[i].gameObject);
                        return instance = instances[instances.Length - 1];
                    }

                    Debug.Log(
                        $"[{nameof(Singleton)}<{typeof(T)}>] An instance is needed in the scene and no existing instances were found, so a new instance will be created.");
                    return instance = new GameObject($"({nameof(Singleton)}){typeof(T)}")
                        .AddComponent<T>();
                }
            }
        }

        [CanBeNull] private static T instance;

        [NotNull]
        // ReSharper disable once StaticMemberInGenericType
        private static readonly object Lock = new object();

        [SerializeField] private bool persistent = true;

        private void Awake()
        {
            var instances = FindObjectsOfType<T>(true);
            var count = instances.Length;
            if (count > 1)
            {
                Debug.LogWarning(
                $"[{nameof(Singleton)}<{typeof(T)}>] There should never be more than one {nameof(Singleton)} of type {typeof(T)} in the scene, but {count} were found. The first instance found will be used, and all others will be destroyed.");

                if (instance != this)
                {
                    DestroyImmediate(this.gameObject);
                    return;
                }
            }

            if (count == 1)
                instance = instances[0];

            if (persistent)
                DontDestroyOnLoad(gameObject);

            OnAwake();
        }

        protected virtual void OnAwake()
        {
            
        }
    }

    public abstract class Singleton : MonoBehaviour
    {
        public static bool Quitting { get; private set; }

        private void OnApplicationQuit()
        {
            Quitting = true;
        }
    }
}