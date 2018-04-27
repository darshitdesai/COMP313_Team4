
/*Author: Anjali Patel
Date: March 21, 2018 */
// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace CabBook.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string SettingsKey = "settings_key";
		private static readonly string SettingsDefault = string.Empty;

		#endregion

		public static string GeneralSettings
		{
			get
			{
				return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(SettingsKey, value);
			}
		}

        private const string IsLoggedInKey = "isLoggedIn_key";
        private static readonly bool IsLoggedInDefault = false;

        public static bool IsLoggedIn
        {
            get
            {
                return AppSettings.GetValueOrDefault(IsLoggedInKey, IsLoggedInDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IsLoggedInKey, value);
            }
        }

        private const string AccessTokenKey = "iccessToken_key";
        private static readonly string AccessTokenDefault = "iccessToken_value";

        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(AccessTokenKey, AccessTokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(AccessTokenKey, value);
            }
        }

        private const string UserIdKey = "userId_key";
        private static readonly string UserIdDefault = "UserId_value";

        public static string UserId
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserIdKey, UserIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserIdKey, value);
            }
        }


        private const string UserRoleKey = "userRole_key";
        private static readonly string UserRoleDefault = "UserRole_value";
        public static string UserRole
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserRoleKey, UserRoleDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserRoleKey, value);
            }
        }

    }
}