using System;
using Xamarin.Essentials;

namespace DevCodePOC.Models
{
    public static class SavePrefrences
    {
       
        public static void AddValue(string key, string value)
        {
            Preferences.Set(key, value);
        }

        public static string GetValue(string key)
        {
            if(Preferences.ContainsKey(key))
                return Preferences.Get(key,string.Empty);

            return null;
        }
    }
}
