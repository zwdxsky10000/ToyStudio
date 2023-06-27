namespace ToyStudio.Engine.Platform
{
    public static class Platform
    {
        private static IPlatform s_instance;
        
        public static IPlatform Instance
        {
            get
            {
                if (s_instance == null)
                {
#if UNITY_ANDROID
                    s_Instnce = new PlatformAndroid();                    
#elif UNITY_IOS
                    s_Instnce = new PlatformIOS();
#else
                    s_instance = new PlatformPC();
#endif
                }

                return s_instance;
            }
            
        }
    }
}