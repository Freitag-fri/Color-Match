using UnityEngine;

namespace Assets.Scripts
{
    // Single access point for persistent data. Key strings live here and nowhere else.
    public static class SaveData
    {
        private const string highScoreKey = "HighScore";
        // private const string volume = "Volume";

        public static int HighScore
        {
            get => PlayerPrefs.GetInt(highScoreKey, 0);
            set
            {
                PlayerPrefs.SetInt(highScoreKey, value);
                PlayerPrefs.Save();
            } 
        }

        // public static int Volume
        // {
        //     get => PlayerPrefs.GetInt(volume, 50);
        //     set
        //     {
        //         PlayerPrefs.SetInt(volume, value);
        //         PlayerPrefs.Save();
        //     }
        // }
    }
}