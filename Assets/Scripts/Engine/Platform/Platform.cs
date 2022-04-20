namespace Engine.Platform
{
    public static class Platform
    {
        private static IPlatform s_Instance = null;
        
        public static IPlatform Instance
        {
            get
            {
                if (s_Instance == null)
                {
#if UNITY_ANDROID
                    s_Instnce = new PlatformAndroid();                    
#elif UNITY_IOS
                    s_Instnce = new PlatformIOS();
#else
                    s_Instance = new PlatformPC();
#endif
                }

                return s_Instance;
            }
            
        }
    }
}