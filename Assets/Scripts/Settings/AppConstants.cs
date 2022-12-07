using UnityEngine;

namespace Chebureck.Settings
{
    public class AppConstants
    {
        #region Cache
        public const string LOCAL_USER_DATA_FILE_PATH = "/1809C9DA5B3CDF.data";
        public const string ADDITIONAL_LOCAL_DATA_FILE_PATH = "/1809C9DA5BTNHD2354F.data";
        public const string ENCRYPT_KEY_DATA = "PRIVATE_KEY_TANDC_noetonetochno";

        public static string PATH_TO_GAMES_CACHE = $"{Application.persistentDataPath}/Game";
        #endregion

        #region Gameplay
        public static bool IS_TEST_MODE = false;

        public static int MAX_ITEMS_ON_SCENE = 1500;
        #endregion
    }
}