using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace FiguresGame
{
    public class ActiveEntitiesBehavior: IContextInit, IContextEnable, IContextDispose, IEntityDispose
    {
        private readonly List<IEntity> _hiddenFigures = new();
        private readonly List<IEntity> _activeEntities = new();
        private List<Transform> _positions;
        private const int FIRST_SPAWN_POSITION = 0;
        void IContextInit.Init(IContext context)
        {
            _positions = context.GetSpawner().SpawnPoints;
        }

        void IContextEnable.Enable(IContext context)
        {
            context.GetSpawner().OnEntitySpawned.Subscribe(AddEntity);
            context.GetSpawner().OnAllEntitySpawned += ActivateEntities;
        }

        public void ActivateEntities()
        {
            var positionIndex = FIRST_SPAWN_POSITION;
            
            while (_hiddenFigures.Count > 0)
            {
                var entity = GetRandomFigure(_hiddenFigures);
                var entityTransform = entity.GetEntityTransform();
                entityTransform.position = _positions[positionIndex].position;
                _activeEntities.Add(entity);
                _hiddenFigures.Remove(entity);
                entityTransform.gameObject.SetActive(true);
                positionIndex++;
                
                if (positionIndex == _positions.Count)
                {   
                    positionIndex = 0;
                }
            }
            
            _hiddenFigures.Clear();
        }
        
        private IEntity GetRandomFigure(List<IEntity> entities)
        {
            var index = Random.Range(0, entities.Count - 1);
            IEntity entity = entities[index];
            return entity;
        }

        private void AddEntity(IEntity entity)
        {
            _hiddenFigures.Add(entity);
            entity.GetOnEntityDestroy().Subscribe(DeleteEntity);
        }

        private void DeleteEntity(IEntity entity)
        {
            var objectType = entity.GetObjectType().Value;

            for (var index = 0; index < _activeEntities.Count; index++)
            {
                var activeEntity = _activeEntities[index];
                var activeEntityType = activeEntity.GetObjectType().Value;

                if (objectType == activeEntityType)
                {
                    _activeEntities.Remove(activeEntity);
                }
            }

            if (_activeEntities.Count == 0)
            {
                Debug.Log($"<color=red>GAMEOVER</color>");
            }
        }

        public void HideFigures()
        {
            foreach (var activeEntity in _activeEntities)
            {
                activeEntity.GetEntityTransform().gameObject.SetActive(false);
                _hiddenFigures.Add(activeEntity);
            }
            
            _activeEntities.Clear();
        }

        void IContextDispose.Dispose(IContext context)
        {
            context.GetSpawner().OnEntitySpawned.Unsubscribe(AddEntity);
            context.GetSpawner().OnAllEntitySpawned -= ActivateEntities;
        }

        public void Dispose(IEntity entity)
        {
            entity.GetOnEntityDestroy().Unsubscribe(DeleteEntity);
        }
    }
}