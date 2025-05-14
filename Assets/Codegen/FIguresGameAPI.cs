/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Contexts;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace FiguresGame
{
	public static class FIguresGameAPI
	{
		///Keys
		public const int Spawner = 1; // SpawnerInstaller
		public const int FiguresContainer = 11; // Transform


		///Extensions
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SpawnerInstaller GetSpawner(this IContext obj) => obj.ResolveValue<SpawnerInstaller>(Spawner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetSpawner(this IContext obj, out SpawnerInstaller value) => obj.TryResolveValue(Spawner, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddSpawner(this IContext obj, SpawnerInstaller value) => obj.AddValue(Spawner, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelSpawner(this IContext obj) => obj.DelValue(Spawner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetSpawner(this IContext obj, SpawnerInstaller value) => obj.SetValue(Spawner, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasSpawner(this IContext obj) => obj.HasValue(Spawner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetFiguresContainer(this IContext obj) => obj.ResolveValue<Transform>(FiguresContainer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFiguresContainer(this IContext obj, out Transform value) => obj.TryResolveValue(FiguresContainer, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddFiguresContainer(this IContext obj, Transform value) => obj.AddValue(FiguresContainer, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFiguresContainer(this IContext obj) => obj.DelValue(FiguresContainer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFiguresContainer(this IContext obj, Transform value) => obj.SetValue(FiguresContainer, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFiguresContainer(this IContext obj) => obj.HasValue(FiguresContainer);
    }
}
