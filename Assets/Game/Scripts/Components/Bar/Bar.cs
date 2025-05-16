using System;
using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace FiguresGame
{
    [Serializable]
    public class Bar: IContextInstaller
    {
        [SerializeField] private List<Transform> _barPositions = new();
        private List<IEntity> _entitiesBar = new();

        public void Install(IContext context)
        {
            context.GetSpawner().OnEntitySpawned.Subscribe(Subscribes);
        }

        private void Subscribes(IEntity entity)
        {
            entity.GetOnEntityClick().Subscribe(GetMoveDirectionTransform);
            entity.GetOnBarPosition().Subscribe(EntityInBar);
            entity.GetOnEntityDestroy().Subscribe(Unsubscribes);
            Debug.Log("BarSubscribes");
        }

        private void EntityInBar(IEntity entity)
        {
            _entitiesBar.Add(entity);
            Debug.Log("InBar");
        }

        private void GetMoveDirectionTransform(IEntity entity)
        {
            if (_barPositions.Count == _entitiesBar.Count)
            {
                return;
            }
            
            var entityRigidBody = entity.GetEntityTransform().gameObject.GetComponent<Rigidbody2D>();
            entityRigidBody.bodyType = RigidbodyType2D.Kinematic;
            entityRigidBody.angularVelocity = 0;
            entityRigidBody.linearVelocity = Vector2.zero;
            var entityCollider = entity.GetFigureCollider();
            Debug.Log(entityCollider);
            entityCollider.enabled = false;
            entity.GetTargetPoint().Value = _barPositions[_entitiesBar.Count].position;
            _entitiesBar.Add(entity);
            Debug.Log("Set Target Point");
        }

        private void Unsubscribes(IEntity entity)
        {
            entity.GetOnEntityClick().Unsubscribe(GetMoveDirectionTransform);
            entity.GetOnBarPosition().Unsubscribe(EntityInBar);
            entity.GetOnEntityDestroy().Unsubscribe(Unsubscribes);
        }

        public void AddEntity(IEntity entity)
        {
            _entitiesBar.Add(entity);
        }

        public Transform GetBarPosition()
        {
            return _barPositions[_barPositions.Count];
        }
    }
}