/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;
using Atomic.Extensions;
using GameExample.Engine;
using Unity.Mathematics;
using System.Collections.Generic;

namespace FiguresGame
{
    public static class FigureValueAPI
    {
        ///Keys
        public const int AnimalImages = 11; // Sprite[]
        public const int SpriteRenderer = 6; // SpriteRenderer
        public const int Prefabs = 7; // List<SceneEntity>
        public const int SpriteColors = 13; // Color[]
        public const int AnimalSpriteRenderer = 14; // SpriteRenderer
        public const int ObjectType = 15; // int


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Sprite[] GetAnimalImages(this IEntity obj) => obj.GetValue<Sprite[]>(AnimalImages);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAnimalImages(this IEntity obj, out Sprite[] value) => obj.TryGetValue(AnimalImages, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAnimalImages(this IEntity obj, Sprite[] value) => obj.AddValue(AnimalImages, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAnimalImages(this IEntity obj) => obj.HasValue(AnimalImages);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAnimalImages(this IEntity obj) => obj.DelValue(AnimalImages);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAnimalImages(this IEntity obj, Sprite[] value) => obj.SetValue(AnimalImages, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpriteRenderer GetSpriteRenderer(this IEntity obj) => obj.GetValue<SpriteRenderer>(SpriteRenderer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetSpriteRenderer(this IEntity obj, out SpriteRenderer value) => obj.TryGetValue(SpriteRenderer, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddSpriteRenderer(this IEntity obj, SpriteRenderer value) => obj.AddValue(SpriteRenderer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasSpriteRenderer(this IEntity obj) => obj.HasValue(SpriteRenderer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelSpriteRenderer(this IEntity obj) => obj.DelValue(SpriteRenderer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetSpriteRenderer(this IEntity obj, SpriteRenderer value) => obj.SetValue(SpriteRenderer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<SceneEntity> GetPrefabs(this IEntity obj) => obj.GetValue<List<SceneEntity>>(Prefabs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetPrefabs(this IEntity obj, out List<SceneEntity> value) => obj.TryGetValue(Prefabs, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddPrefabs(this IEntity obj, List<SceneEntity> value) => obj.AddValue(Prefabs, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasPrefabs(this IEntity obj) => obj.HasValue(Prefabs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelPrefabs(this IEntity obj) => obj.DelValue(Prefabs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetPrefabs(this IEntity obj, List<SceneEntity> value) => obj.SetValue(Prefabs, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color[] GetSpriteColors(this IEntity obj) => obj.GetValue<Color[]>(SpriteColors);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetSpriteColors(this IEntity obj, out Color[] value) => obj.TryGetValue(SpriteColors, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddSpriteColors(this IEntity obj, Color[] value) => obj.AddValue(SpriteColors, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasSpriteColors(this IEntity obj) => obj.HasValue(SpriteColors);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelSpriteColors(this IEntity obj) => obj.DelValue(SpriteColors);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetSpriteColors(this IEntity obj, Color[] value) => obj.SetValue(SpriteColors, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpriteRenderer GetAnimalSpriteRenderer(this IEntity obj) => obj.GetValue<SpriteRenderer>(AnimalSpriteRenderer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAnimalSpriteRenderer(this IEntity obj, out SpriteRenderer value) => obj.TryGetValue(AnimalSpriteRenderer, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAnimalSpriteRenderer(this IEntity obj, SpriteRenderer value) => obj.AddValue(AnimalSpriteRenderer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAnimalSpriteRenderer(this IEntity obj) => obj.HasValue(AnimalSpriteRenderer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAnimalSpriteRenderer(this IEntity obj) => obj.DelValue(AnimalSpriteRenderer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAnimalSpriteRenderer(this IEntity obj, SpriteRenderer value) => obj.SetValue(AnimalSpriteRenderer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetObjectType(this IEntity obj) => obj.GetValue<int>(ObjectType);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetObjectType(this IEntity obj, out int value) => obj.TryGetValue(ObjectType, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddObjectType(this IEntity obj, int value) => obj.AddValue(ObjectType, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasObjectType(this IEntity obj) => obj.HasValue(ObjectType);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelObjectType(this IEntity obj) => obj.DelValue(ObjectType);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetObjectType(this IEntity obj, int value) => obj.SetValue(ObjectType, value);
    }
}
