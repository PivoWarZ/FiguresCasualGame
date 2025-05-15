using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace FiguresGame
{
    public class ActivatorBehavior: IContextInit, IContextEnable, IContextDispose
    {
        private List<IEntity> _spawnedEntities = new();
        private List<IEntity> _activeEntities = new();
        private List<Transform> _positions;
        private const int FIRST_SPAWN_POSITION = 0;
        void IContextInit.Init(IContext context)
        {
            _positions = context.GetSpawner().SpawnPoints;
        }

        void IContextEnable.Enable(IContext context)
        {
            Debug.Log("Enabling spawn points");
            context.GetSpawner().OnEntitySpawned.Subscribe(AddEntity);
            context.GetSpawner().OnAllEntitySpawned += ActivateEntitys;
        }

        private void ActivateEntitys()
        {
            var positionIndex = FIRST_SPAWN_POSITION;
            
            while (_spawnedEntities.Count - 1 > 0)
            {
                var index = Random.Range(0, _spawnedEntities.Count - 1);
                IEntity entity = _spawnedEntities[index];
                var entityTransform = entity.GetEntityTransform();
                entityTransform.position = _positions[positionIndex].position;
                _activeEntities.Add(entity);
                _spawnedEntities.Remove(entity);
                entityTransform.gameObject.SetActive(true);
                positionIndex++;
                
                if (positionIndex == _positions.Count)
                {   
                    positionIndex = 0;
                }
            }
        }

        private void AddEntity(IEntity obj)
        {
            _spawnedEntities.Add(obj);
        }

        private int GetRandomIndexPosition()
        {
            return Random.Range(0, _positions.Count - 1);
        }

        void IContextDispose.Dispose(IContext context)
        {
            context.GetSpawner().OnEntitySpawned.Unsubscribe(AddEntity);
            context.GetSpawner().OnAllEntitySpawned -= ActivateEntitys;
        }
    }
}