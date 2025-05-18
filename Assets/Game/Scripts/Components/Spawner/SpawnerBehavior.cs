using System.Collections.Generic;
using Atomic.Contexts;
using UnityEngine;
using Atomic.Entities;
using Random = UnityEngine.Random;

namespace FiguresGame
{
    public sealed class SpawnerBehavior: IContextInit, IContextEnable
    {
        private SpawnerInstaller _spawner;
        private List<SceneEntity> _prefabs = new();
        private Transform _figuresContainer;
        private const int FIRST_POOL_NUMBER = 0;

        void IContextInit.Init(IContext context)
        {
            _spawner = context.GetSpawner();
            _prefabs = _spawner.Prefabs;
            _figuresContainer = context.GetFiguresContainer();
        }

        void IContextEnable.Enable(IContext context)
        {
            _spawner.OnSpawn += Spawn;
        }
        
        private void Spawn(int count)
        {
            var index = FIRST_POOL_NUMBER;
            
            SceneEntity prefab = GetRandomEntity();
            
            while (count > 0)
            {
                if (index % _spawner.PoolSize == 0)
                {
                    prefab = GetRandomEntity();
                }
                
                IEntity entity = SceneEntity.Instantiate(prefab, _figuresContainer);
                entity.GetID().Value = count;
                _spawner.OnEntitySpawned.Invoke(entity);
                index++;
                count--;
            }
            
            _spawner.OnAllEntitySpawned.Invoke();
        }

        private SceneEntity GetRandomEntity()
        {
            SceneEntity entity = _prefabs[Random.Range(0, _prefabs.Count)];
            return entity;
        }
    }
}