using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace FiguresGame
{
    public class ActiveEntitiesBehavior: IContextInit, IContextEnable, IContextDispose, IEntityDispose, IContextUpdate
    {
        public ReactiveVariable<int> ActiveEntitiesCount = new ();
        
        private readonly List<IEntity> _hiddenFigures = new();
        private readonly List<IEntity> _activeEntities = new();
        private List<Transform> _positions;
        private Timer _timer;
        private int _positionIndex;
        
        void IContextInit.Init(IContext context)
        {
            _positions = context.GetSpawner().SpawnPoints;
            _timer = context.GetTimer();
        }

        void IContextEnable.Enable(IContext context)
        {
            context.GetSpawner().OnEntitySpawned.Subscribe(AddEntity);
            context.GetSpawner().OnAllEntitySpawned += StartTimer;
            _timer.OnStarted += ActivateEntities;
        }

        private void StartTimer()
        {
            _timer.Start();
        }

        public void ActivateEntities()
        {
            if (_hiddenFigures.Count <= 0)
            {
                _timer.Stop();
                _hiddenFigures.Clear();
                return;
            }
            
            var entity = GetRandomFigure(_hiddenFigures);
            var entityTransform = entity.GetEntityTransform();
            entityTransform.position = _positions[_positionIndex].position;
            _activeEntities.Add(entity);
            _hiddenFigures.Remove(entity);
            entityTransform.gameObject.SetActive(true);
            ActiveEntitiesCount.Value++;
            _positionIndex++;
            
            if (_positionIndex == _positions.Count)
            {   
                _positionIndex = 0;
            }
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
            entity.GetOnBarPosition().Subscribe(DeleteEntity);
        }

        private void DeleteEntity(IEntity entity)
        {
            var id = entity.GetID().Value;

            for (var index = 0; index < _activeEntities.Count; index++)
            {
                var activeEntity = _activeEntities[index];
                var activeEntityID = activeEntity.GetID().Value;

                if (id == activeEntityID)
                {
                    _activeEntities.Remove(activeEntity);
                    ActiveEntitiesCount.Value--;
                    return;
                }
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

        public void TimerStart()
        {
            _timer.Start();
        }

        void IContextDispose.Dispose(IContext context)
        {
            context.GetSpawner().OnEntitySpawned.Unsubscribe(AddEntity);
            context.GetSpawner().OnAllEntitySpawned -= ActivateEntities;
            _timer.OnStarted -= ActivateEntities;
        }

        public void Dispose(IEntity entity)
        {
            entity.GetOnBarPosition().Unsubscribe(DeleteEntity);
        }

        public void Update(IContext context, float deltaTime)
        {
            _timer.Tick(deltaTime);
        }
    }
}