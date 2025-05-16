using System;
using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace FiguresGame
{
    [Serializable]
    public class BarInstaller: IContextSystem
    {
        [SerializeField] private List<Transform> _barPositions = new();
        private List<IEntity> _entitiesBar = new();

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