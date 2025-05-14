/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;

namespace FiguresGame
{
    public static class EntityTagAPI
    {
        ///Keys
        public const int Yellow = 1;
        public const int Green = 2;
        public const int Blue = 3;


        ///Extensions
        public static bool HasYellowTag(this IEntity obj) => obj.HasTag(Yellow);
        public static bool AddYellowTag(this IEntity obj) => obj.AddTag(Yellow);
        public static bool DelYellowTag(this IEntity obj) => obj.DelTag(Yellow);

        public static bool HasGreenTag(this IEntity obj) => obj.HasTag(Green);
        public static bool AddGreenTag(this IEntity obj) => obj.AddTag(Green);
        public static bool DelGreenTag(this IEntity obj) => obj.DelTag(Green);

        public static bool HasBlueTag(this IEntity obj) => obj.HasTag(Blue);
        public static bool AddBlueTag(this IEntity obj) => obj.AddTag(Blue);
        public static bool DelBlueTag(this IEntity obj) => obj.DelTag(Blue);
    }
}
