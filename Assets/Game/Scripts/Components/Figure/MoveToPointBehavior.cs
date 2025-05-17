using Atomic.Entities;
using UnityEngine;

namespace FiguresGame
{
    public class MoveToPointBehavior: IEntityUpdate, IEntityDispose, IEntityEnable, IEntityInit
    {
        private bool _isMoving;
        void IEntityUpdate.OnUpdate(IEntity entity, float deltaTime)
        {
            if (!_isMoving)
            {
                return;
            }
            
            entity.GetMoveDirection().Value = entity.GetTargetPoint().Value - entity.GetEntityTransform().position;
            entity.GetEntityTransform().position += entity.GetMoveDirection().Value.normalized * (entity.GetMoveSpeed().Value * deltaTime);

            if (entity.GetMoveDirection().Value.sqrMagnitude <= 0.01f)
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
            Debug.Log("Dispose Entity");
            entity.GetOnEntityDestroy()?.Invoke(entity);
        }

        public void Init(IEntity entity)
        {
            _isMoving = false;
        }
        
    }
}