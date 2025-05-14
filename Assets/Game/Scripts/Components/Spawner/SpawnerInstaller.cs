using System;
using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;
using Timer = Atomic.Elements.Timer;
using Event = Atomic.Elements.Event;

namespace FiguresGame
{
    [Serializable]
    public class SpawnerInstaller: IContextInstaller
    {
        public event Action<int> OnSpawn;
        public Event<IEntity> OnEntitySpawned = new();
        
        [SerializeField] private SceneEntity _prefab;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private int _spawnCount;
        [SerializeField] private Timer _timer;
        public void Install(IContext context)
        {
            context.AddSystem(new SpawnerBehavior());
        }
        
        public SceneEntity Prefab => _prefab;
        public List<Transform> SpawnPoints => _spawnPoints;
        public Timer Timer => _timer;

        [Button]
        public void Spawn(int count)
        {
            Debug.Log($"Spawning  {count}");
            OnSpawn?.Invoke(count);
        }
    }
}