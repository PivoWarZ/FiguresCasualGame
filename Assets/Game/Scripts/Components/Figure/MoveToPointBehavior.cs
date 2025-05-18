using Atomic.Entities;
using UnityEngine;

namespace FiguresGame
{
    public sealed class MoveToPointBehavior: IEntityUpdate, IEntityDispose, IEntityEnable, IEntityInit
    {
        private bool _isMoving;
        private const float STAY_IN = 0.01f;
        
        void IEntityUpdate.OnUpdate(IEntity entity, float deltaTime)
        {
            if (!_isMoving)
            {
                return;
            }
            
            entity.GetMoveDirection().Value = entity.GetTargetPoint().Value - entity.GetEntityTransform().position;
            entity.GetEntityTransform().position += entity.GetMoveDirection().Value.normalized * (entity.GetMoveSpeed().Value * deltaTime);

            if (entity.GetMoveDirection().Value.sqrMagnitude <= STAY_IN)
            {
                entity.GetOnBarPosition().Invoke(entity);
                entity.GetTargetPoint().Value = Vector3.zero;
                _isMoving = false;
            }
        }

        public void Enable(IEntity entity)
        {
            entity.GetTargetPoint().Subscribe(Move);
        }

        private void Move(Vector3 obj)
        {
            _isMoving = true;
        }

        public void Dispose(IEntity entity)
        {
            entity.GetTargetPoint().Unsubscribe(Move);
            entity.GetOnEntityDestroy()?.Invoke(entity);
        }

        public void Init(IEntity entity)
        {
            _isMoving = false;
        }
    }
}