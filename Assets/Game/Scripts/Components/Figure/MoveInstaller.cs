using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace FiguresGame
{
    [Serializable]
    public class MoveInstaller: IEntityInstaller

    {
        [SerializeField] private ReactiveVariable<Vector3> _moveDirection = Vector3.zero;
        [SerializeField] private float _moveSpeed = 10f;
        private ReactiveVariable<Vector3> _targetPoint = Vector3.zero;
        public void Install(IEntity entity)
        {
            entity.AddTargetPoint(_targetPoint);
            entity.AddMoveDirection(_moveDirection);
            entity.AddMoveSpeed(_moveSpeed);
        }
    }
}