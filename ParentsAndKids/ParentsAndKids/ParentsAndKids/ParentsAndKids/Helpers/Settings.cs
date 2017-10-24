using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ParentsAndKids.Helpers {
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings {
        private static ISettings AppSettings {
            get {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string AccessToken = "access_token";
        private const string SettingsKey = "settings_key";
        private const string IdUseMocks = "use_mocks";
        private static readonly string AccessTokenDefault = string.Empty;
        private static readonly string SettingsDefault = string.Empty;
        private static readonly bool UseMocksDefault = true;

        #endregion

        public static string AuthAccessToken {
            get => AppSettings.GetValueOrDefault(AccessToken, AccessTokenDefault);
            set => AppSettings.AddOrUpdateValue(AccessToken, value);
        }

        public static string GeneralSettings {
            get => AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(SettingsKey, value);
        }

        public static bool UseMocks {
            get => AppSettings.GetValueOrDefault(IdUseMocks, UseMocksDefault);
            set => AppSettings.AddOrUpdateValue(IdUseMocks, value);
        }

    }
}