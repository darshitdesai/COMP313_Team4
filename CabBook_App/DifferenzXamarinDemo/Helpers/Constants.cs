using System;
namespace CabBook
{
    /// <summary>
    /// Constants. - Contains titles/messages being used throughout application
    /// </summary>
    public static class Constants
    {
        public static readonly string TITLE_LOADING = "Loading....";
        public static readonly string TITLE_AUTHENTICATING = "Authenticating....";
        public static readonly string TITLE_LOGOUT = "Logout....";
        public static readonly string TITLE_SAVING = "Saving....";
        public static readonly string TITLE_DELETING = "Deleting....";
        public static readonly string TITLE_PLEASE_WAIT = "Please wait....";

        public static readonly string TITLE_ERROR = "Error";
        public static readonly string TITLE_SUCCESS = "Success";
        public static readonly string TITLE_VALIDATION_ERROR = "Validation Error";

        public static readonly string MESSAGE_SUCCESS_DATA_UPDATED = "Your data is updated.";
        public static readonly string MESSAGE_ERROR_INSERT_ALL_DATA = "Please insert all data.";
        public static readonly string MESSAGE_ERROR_EMAIL_PASSWORD_ERROR = "Invalid email or password.";
        public static readonly string MESSAGE_ERROR_SOMETHING_WENT_WRONG_WITH_USER_LOGIN = "Sorry! something went wrong with the login process.";
        public static readonly string MESSAGE_ERROR_SESSION_EXPIRED = "Your session is expired, Please login again.";
        public static readonly string MESSAGE_ERROR_SOMETHING_WENT_WRONG = "Sorry! something went wrong.";

        public static readonly string MESSAGE_ERROR_INVALID_EMAIL = "Please enter valid email.";

        public static readonly string MESSAGE_ERROR_INVALID_CONTACT_NO = "Please enter valid contact number";

        public static readonly string TEXT_OK = "OK";
        public static readonly string TEXT_LOGOUT = "Logout";
        public static readonly string TEXT_CANCEL = "Cancel";

        public static readonly string TEXT_UPDATE = "Update";
        public static readonly string TEXT_DELETE = "Delete";
        public static readonly string TEXT_SAVE = "Save";

        public static readonly string EMAIL_REGEX = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public static readonly string PHONE_NO_REGEX = @"\d{10}";
    }
}
