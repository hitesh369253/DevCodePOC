using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DevCodePOC.UITest
{
    public class AppInitializer
    {
        #region App Null Check
        static IApp app;
        public static IApp App
        {
            get
            {
                _ = app ?? throw new NullReferenceException("AppInitializer.App is not set.");
                return app;
            }
        }
        #endregion

        #region Platform Null Check
        static Platform? platform;
        public static Platform Platform
        {
            get
            {
                _ = platform ?? throw new NullReferenceException("AppInitializer.Platform is not set.");
                return platform.Value;
            }

            set
            {
                platform = value;
            }
        }
        #endregion

        #region StartApp
        /// <summary>
        /// StartApp is used to install/launch the mobile app
        /// </summary>
        public static void StartApp()
        {
            string ApkPath, AppPath;
           
            ApkPath = "/Users/hiteshkumarsunkarapeli/Downloads/DevCodePOC/DevCodePOC.Android/bin/Debug/com.companyname.appname.apk";
            AppPath = "E4C4BB27-479E-4784-82C3-F40989D48440";
            if (platform.Equals(Platform.Android))
            {
                app = ConfigureApp.Android.ApkFile(ApkPath).WaitTimes(new WaitTimes()).EnableLocalScreenshots().StartApp();
            }
            if (platform.Equals(Platform.iOS))
            {
                app = ConfigureApp.iOS.DeviceIdentifier(AppPath).InstalledApp("com.companyname.appname").WaitTimes(new WaitTimes()).EnableLocalScreenshots().StartApp();
            }
        }
        #endregion
    }
}
