using System.Collections.Generic;
using Atomic.Entities;
using UnityEngine;

namespace FiguresGame
{
    public class BarInstaller: SceneEntityInstallerBase
    {
        [SerializeField] private List<Transform> _barPositions = new();
        private List<IEntity> _entitiesBar = new();
        
        public override void Install(IEntity entity)
        {
            entity.AddBarPositions(_barPositions);
            entity.AddEntityBar(_entitiesBar);
        }
    }
}