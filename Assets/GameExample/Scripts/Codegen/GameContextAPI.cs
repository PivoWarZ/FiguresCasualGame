/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Contexts;
using System.Runtime.CompilerServices;
using Atomic.Entities;
using Atomic.Elements;
using System.Collections.Generic;
using GameExample.Engine;

namespace FiguresGame
{
	public static class GameContextAPI
	{
		///Keys
		public const int PlayerMap = 5; // Dictionary<TeamType, IContext>
		public const int GameCountdown = 10; // Countdown
		public const int CoinSystemData = 13; // CoinSystemData
		public const int WorldTransform = 7; // Transform
		public const int ActivesEntities = 14; // ActiveEntitiesBehavior
		public const int Timer = 15; // Timer
		public const int OnWinConditionExamination = 16; // IEvent
		public const int OnLoose = 17; // IEvent


		///Extensions
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Dictionary<TeamType, IContext> GetPlayerMap(this IContext obj) => obj.ResolveValue<Dictionary<TeamType, IContext>>(PlayerMap);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPlayerMap(this IContext obj, out Dictionary<TeamType, IContext> value) => obj.TryResolveValue(PlayerMap, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPlayerMap(this IContext obj, Dictionary<TeamType, IContext> value) => obj.AddValue(PlayerMap, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPlayerMap(this IContext obj) => obj.DelValue(PlayerMap);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPlayerMap(this IContext obj, Dictionary<TeamType, IContext> value) => obj.SetValue(PlayerMap, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPlayerMap(this IContext obj) => obj.HasValue(PlayerMap);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Countdown GetGameCountdown(this IContext obj) => obj.ResolveValue<Countdown>(GameCountdown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameCountdown(this IContext obj, out Countdown value) => obj.TryResolveValue(GameCountdown, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddGameCountdown(this IContext obj, Countdown value) => obj.AddValue(GameCountdown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameCountdown(this IContext obj) => obj.DelValue(GameCountdown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameCountdown(this IContext obj, Countdown value) => obj.SetValue(GameCountdown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameCountdown(this IContext obj) => obj.HasValue(GameCountdown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static CoinSystemData GetCoinSystemData(this IContext obj) => obj.ResolveValue<CoinSystemData>(CoinSystemData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCoinSystemData(this IContext obj, out CoinSystemData value) => obj.TryResolveValue(CoinSystemData, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCoinSystemData(this IContext obj, CoinSystemData value) => obj.AddValue(CoinSystemData, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCoinSystemData(this IContext obj) => obj.DelValue(CoinSystemData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCoinSystemData(this IContext obj, CoinSystemData value) => obj.SetValue(CoinSystemData, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCoinSystemData(this IContext obj) => obj.HasValue(CoinSystemData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetWorldTransform(this IContext obj) => obj.ResolveValue<Transform>(WorldTransform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWorldTransform(this IContext obj, out Transform value) => obj.TryResolveValue(WorldTransform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddWorldTransform(this IContext obj, Transform value) => obj.AddValue(WorldTransform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWorldTransform(this IContext obj) => obj.DelValue(WorldTransform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWorldTransform(this IContext obj, Transform value) => obj.SetValue(WorldTransform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWorldTransform(this IContext obj) => obj.HasValue(WorldTransform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ActiveEntitiesBehavior GetActivesEntities(this IContext obj) => obj.ResolveValue<ActiveEntitiesBehavior>(ActivesEntities);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetActivesEntities(this IContext obj, out ActiveEntitiesBehavior value) => obj.TryResolveValue(ActivesEntities, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddActivesEntities(this IContext obj, ActiveEntitiesBehavior value) => obj.AddValue(ActivesEntities, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelActivesEntities(this IContext obj) => obj.DelValue(ActivesEntities);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetActivesEntities(this IContext obj, ActiveEntitiesBehavior value) => obj.SetValue(ActivesEntities, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasActivesEntities(this IContext obj) => obj.HasValue(ActivesEntities);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Timer GetTimer(this IContext obj) => obj.ResolveValue<Timer>(Timer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTimer(this IContext obj, out Timer value) => obj.TryResolveValue(Timer, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTimer(this IContext obj, Timer value) => obj.AddValue(Timer, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTimer(this IContext obj) => obj.DelValue(Timer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTimer(this IContext obj, Timer value) => obj.SetValue(Timer, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTimer(this IContext obj) => obj.HasValue(Timer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetOnWinConditionExamination(this IContext obj) => obj.ResolveValue<IEvent>(OnWinConditionExamination);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetOnWinConditionExamination(this IContext obj, out IEvent value) => obj.TryResolveValue(OnWinConditionExamination, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddOnWinConditionExamination(this IContext obj, IEvent value) => obj.AddValue(OnWinConditionExamination, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelOnWinConditionExamination(this IContext obj) => obj.DelValue(OnWinConditionExamination);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetOnWinConditionExamination(this IContext obj, IEvent value) => obj.SetValue(OnWinConditionExamination, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasOnWinConditionExamination(this IContext obj) => obj.HasValue(OnWinConditionExamination);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetOnLoose(this IContext obj) => obj.ResolveValue<IEvent>(OnLoose);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetOnLoose(this IContext obj, out IEvent value) => obj.TryResolveValue(OnLoose, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddOnLoose(this IContext obj, IEvent value) => obj.AddValue(OnLoose, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelOnLoose(this IContext obj) => obj.DelValue(OnLoose);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetOnLoose(this IContext obj, IEvent value) => obj.SetValue(OnLoose, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasOnLoose(this IContext obj) => obj.HasValue(OnLoose);
    }
}
