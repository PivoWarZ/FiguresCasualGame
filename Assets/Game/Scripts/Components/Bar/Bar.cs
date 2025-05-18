using System;
using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;
using Event = Atomic.Elements.Event;

namespace FiguresGame
{
    [Serializable]
    public sealed class Bar: IContextInstaller, IContextDispose, IContextEnable, IContextInit
    {
        public Event OnLoose = new();
        
        [SerializeField] private List<Transform> _barPositions = new();
        private List<IEntity> _transitEntities = new();
        private List<IEntity> _entitiesBar = new();
        private int pool;

        public void Install(IContext context)
        {
            context.AddOnLoose(OnLoose);
        }

        void IContextInit.Init(IContext context)
        {
            pool = context.GetSpawner().PoolSize;
        }
        
        void IContextEnable.Enable(IContext context)
        {
            context.GetSpawner().OnEntitySpawned.Subscribe(Subscribes);
        }
        
        private void Subscribes(IEntity entity)
        {
            entity.GetOnEntityClick().Subscribe(GetMoveDirectionTransform);
            entity.GetOnBarPosition().Subscribe(EntityInBar);
            entity.GetOnEntityDestroy().Subscribe(Unsubscribes);
        }

        private void EntityInBar(IEntity entity)
        {
            _entitiesBar.Add(entity);
            
            var objectType = entity.GetObjectType().Value;
            
            ClearList(_transitEntities, objectType, true);
            
            bool isDelete = SearchMatches(entity);

            if (isDelete)
            {
                DeleteBarEntities(objectType);
            }

            if (_entitiesBar.Count == _barPositions.Count)
            {
                OnLoose?.Invoke();
            }
        }

        private void DeleteBarEntities(int objectType)
        {
            List<IEntity> buffer = new List<IEntity>();
            
            foreach (var entity in _entitiesBar)
            {
                if (entity.GetObjectType().Value == objectType)
                {
                    SceneEntity.Destroy(entity.GetEntityTransform().gameObject);
                }
                else
                {
                    buffer.Add(entity);
                }
            }
            
            _entitiesBar.Clear(); 

            foreach (var entity in buffer)
            {
                GetMoveDirectionTransform(entity);
            }
            
            buffer.Clear();
        }

        private void ClearList(List<IEntity> entityList, int objectType, bool firstOnly = false)
        {
            for (var index = 0; index < entityList.Count; index++)
            {
                var entity = entityList[index];
                
                if (entity.GetObjectType().Value == objectType)
                {
                    entityList.Remove(entity);

                    if (firstOnly)
                    {
                        return;
                    }
                }
            }
        }

        private bool SearchMatches(IEntity entity)
        {
            var objectType = entity.GetObjectType().Value;
            int count = 0;
            
            foreach (var barEntity in _entitiesBar)
            {
                var barType = barEntity.GetObjectType().Value;

                if (objectType == barType)
                {
                    count++;
                }
            }

            return count >= pool;
        }

        private void GetMoveDirectionTransform(IEntity entity)
        {
            if (TryGetBarPosition(out Vector3 position))
            {
                SetEntityForTransit(entity);
                entity.GetTargetPoint().Value = position;
                _transitEntities.Add(entity);
            }
        }


        private void SetEntityForTransit(IEntity entity)
        {
            var entityRigidBody = entity.GetEntityTransform().gameObject.GetComponent<Rigidbody2D>();
            entityRigidBody.bodyType = RigidbodyType2D.Kinematic;
            entityRigidBody.angularVelocity = 0;
            entityRigidBody.linearVelocity = Vector2.zero;
            var entityCollider = entity.GetFigureCollider();
            entityCollider.enabled = false;
        }

        public bool TryGetBarPosition(out Vector3 position)
        {
            bool freePosition = true;
            var occupiedPositions = _entitiesBar.Count + _transitEntities.Count;
            if (occupiedPositions == _barPositions.Count)
            {
                position = Vector3.zero;
                freePosition = false;
            }
            else
            {
                position = _barPositions[_entitiesBar.Count + _transitEntities.Count].position;
            }

            return freePosition;
        }

        private void Unsubscribes(IEntity entity)
        {
            entity.GetOnEntityClick().Unsubscribe(GetMoveDirectionTransform);
            entity.GetOnBarPosition().Unsubscribe(EntityInBar);
            entity.GetOnEntityDestroy().Unsubscribe(Unsubscribes);
        }
        
        void IContextDispose.Dispose(IContext context)
        {
            context.GetSpawner().OnEntitySpawned.Unsubscribe(Subscribes);
        }
    }
}