using System;
using Xamarin.Essentials;

namespace XamChat.Helpers
{
    public static class Settings
    {
        public static string AppCenterAndroid = "AC_ANDROID";
        //http://192.168.0.25/XamChat.Backend 192.168.0.25
#if DEBUG
        static readonly string defaultIP = DeviceInfo.Platform == DevicePlatform.Android ? "192.168.0.25/XamChat.Backend" : "localhost";
#else
        static readonly string defaultIP = "xamchatr.azurewebsites.net";
#endif
        public static bool UseHttps
        {
            get => (defaultIP != "localhost" && defaultIP != "192.168.0.25");
        }

        public static string ServerIP
        {
            get => Preferences.Get(nameof(ServerIP), defaultIP);
            set => Preferences.Set(nameof(ServerIP), value);
        }

        static Random random = new Random();
        static readonly string defaultName = $"{DeviceInfo.Platform} User {random.Next(1, 100)}";
        public static string UserName
        {
            get => Preferences.Get(nameof(UserName), defaultName);
            set => Preferences.Set(nameof(UserName), value);
        }

        
        public static string Group
        {
            get => Preferences.Get(nameof(Group), string.Empty);
            set => Preferences.Set(nameof(Group), value);
        }
    }
}
