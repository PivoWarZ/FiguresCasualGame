using System;
using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace FiguresGame
{
    [Serializable]
    public class ServiceLocator: IContextInstaller

    {
        [SerializeField] private Transform _figuresContainer;

        public void Install(IContext context)
        {
            context.AddFiguresContainer(_figuresContainer);
        }
    }
}