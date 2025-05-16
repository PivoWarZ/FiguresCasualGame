using System.Collections.Generic;
using Atomic.Contexts;
using UnityEngine;
using Atomic.Entities;
using Random = UnityEngine.Random;
using Timer = Atomic.Elements.Timer;

namespace FiguresGame
{
    public class SpawnerBehavior: IContextInit, IContextEnable, IContextUpdate, IContextDispose
    {
        private SpawnerInstaller _spawner;
        private List<SceneEntity> _prefabs = new();
        private Transform _figuresContainer;
        private Timer _timer;
        private int _count;
        private const int FIRST_ENTITY_TYPE = 0;
        private const int FIRST_POOL_NUMBER = 0;

        void IContextInit.Init(IContext context)
        {
            _spawner = context.GetSpawner();
            _timer = context.GetSpawner().Timer;
            _prefabs = _spawner.Prefabs;
            _figuresContainer = context.GetFiguresContainer();
        }

        void IContextEnable.Enable(IContext context)
        {
            _timer.OnEnded += Spawn;
            _spawner.OnSpawn += SetCount;
        }

        private void SetCount(int count)
        {
            _count = count;
            _timer.Start();
        }

        public void Update(IContext context, float deltaTime)
        {
            if (_count <= 0)
            {
                return;
            }
            
            _timer.Tick(deltaTime);
        }
        
        private void Spawn()
        {
            var index = FIRST_POOL_NUMBER;
            SceneEntity prefab = GetRandomEntity();
            
            while (_count > 0)
            {
                if (index % _spawner.PoolSize == 0)
                {
                    prefab = GetRandomEntity();
                }
                
                IEntity entity = SceneEntity.Instantiate(prefab, _figuresContainer);
                _spawner.OnEntitySpawned.Invoke(entity);
                index++;
                _count--;
            }
            
            _timer.Stop();
        }

        private SceneEntity GetRandomEntity()
        {
            SceneEntity entity = _prefabs[Random.Range(0, _prefabs.Count - 1)];
            return entity;
        }
        
        void IContextDispose.Dispose(IContext context)
        {
            _timer.OnEnded -= Spawn;
           _spawner.OnSpawn -= SetCount;
        }
    }
}