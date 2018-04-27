/*Author: Savan Patel
Date: March 26, 2018
Purpose: Login Data attribute*/

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CabBook
{
    /// <summary>
    /// LoginModel - Contains attributes for persisting user login data
    /// </summary>
	public class LoginModel
	{
		public LoginModel (){
            Errors = new List<string>();
        }

		public string Email{get;set;}
        public string UserName { get; set; }
        public string Password{get;set;}
		public string DeviceOSType{get;set;}
		public string DeviceUDID{get;set;}
		public string DeviceToken { get; set; }

        public List<string> Errors { get; set; }
	}

    public class Token
    {
        public Token()
        {
            Errors = new List<string>();
        }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("User_id")]
        public string UserId { get; set; }

        [JsonProperty("User_role")]
        public string UserRole { get; set; }

        public List<string> Errors { get; set; }
    }

    /// <summary>
    /// LoginObject - Wraps LoginModel
    /// </summary>
	public class LoginObject
	{
		public LoginModel LoginData{ get; set;}
	}
}

