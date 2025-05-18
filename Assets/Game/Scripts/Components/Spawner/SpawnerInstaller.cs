using System;
using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;
using Timer = Atomic.Elements.Timer;

namespace FiguresGame
{
    [Serializable]
    public class SpawnerInstaller: IContextInstaller
    {
        public event Action<int> OnSpawn;
        public Event<IEntity> OnEntitySpawned = new();
        public Action OnAllEntitySpawned;

        [SerializeField] private List<SceneEntity> _prefabs;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private int _spawnCount;
        [SerializeField] private int _poolSize = 3;
        public void Install(IContext context)
        {
            context.AddSystem(new SpawnerBehavior());
            context.AddSystem(new SetFiguresBehavior());
        }
        
        public List<Transform> SpawnPoints => _spawnPoints;
        public int PoolSize => _poolSize;
        public int SpawnCount => _spawnCount;
        public List<SceneEntity> Prefabs => _prefabs;

        private void AllEntitysSpawned()
        {
            OnAllEntitySpawned?.Invoke();
        }

        [Button]
        public void Spawn(int count)
        {
            OnSpawn?.Invoke(count);
        }

    }
}