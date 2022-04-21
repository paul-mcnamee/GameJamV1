using UnityEngine;

namespace Utils
{
    public static class General
    {
        private static Camera mainCamera;
        public static Camera MainCamera
        {
            get
            {
                if (mainCamera == null) mainCamera = Camera.main;
                return mainCamera;
            }
        }
    }
}
