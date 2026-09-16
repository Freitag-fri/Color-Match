using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class CollorManager
    {
        public enum Collors {
            Green,
            Red,
            Blue,
            Yellow
        }

        private static Dictionary<Collors, Color> _spriteCollorsDictionary = new Dictionary<Collors, Color>()
        {
            {Collors.Green, new Color(0f, 1f, 0f)},
            {Collors.Red, new Color(1f, 0f, 0f)},
            {Collors.Blue, new Color(0f, 0f, 1f)},
            {Collors.Yellow, new Color(1f, 1f, 0f)}
        };

        public static Color GetSpriteCollor(Collors collor)
        {
            return _spriteCollorsDictionary[collor];
        }

        public static Collors GetRandomCollor()
        {
            var values = (Collors[])System.Enum.GetValues(typeof(Collors));
            return values[Random.Range(0, values.Length)];
        }
    }
}
