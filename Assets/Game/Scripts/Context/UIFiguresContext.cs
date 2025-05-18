using System;
using Atomic.Contexts;
using FiguresGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Context
{
    [Serializable]
    public class UIFiguresContext: IContextInit
    {
        private ActiveEntitiesBehavior _activeEntities;
        
        public void Init(IContext context)
        {
            _activeEntities = context.GetActivesEntities();
            Debug.Log("Init" + _activeEntities);
        }
        
        [Button]
        private void Refresh()
        {
            _activeEntities.HideFigures();
            _activeEntities.ActivateEntities();
        }
    }
}