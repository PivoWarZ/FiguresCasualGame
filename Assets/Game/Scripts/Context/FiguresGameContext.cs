using Atomic.Contexts;
using Atomic.Elements;
using Game.Scripts.Components;
using Game.Scripts.Context;
using UnityEngine;
using UnityEngine.Serialization;

namespace FiguresGame
{
    public class FiguresGameContext: SceneContextInstallerBase
    {
        [SerializeField] private ServiceLocator _serviceLocator;
        [SerializeField] private SpawnerInstaller _spawner;
        [SerializeField] private Timer _timer;
        [SerializeField] private Settings _settings;
        [SerializeField] private Bar _bar;
        [SerializeField] private UIFiguresContext _uiFiguresContext;

        public override void Install(IContext context)
        {
            ActiveEntitiesBehavior activeEntitiesBehavior = new ActiveEntitiesBehavior();
            
            context.AddActivesEntities(activeEntitiesBehavior);
            context.AddSpawner(_spawner);
            context.AddSettings(_settings);
            context.AddTimer(_timer);
            
            _serviceLocator.Install(context);
            _spawner.Install(context);
            _bar.Install(context);

            context.AddSystem(new InputBehavior());
            context.AddSystem(activeEntitiesBehavior);
            context.AddSystem(_uiFiguresContext);
        }
    }
}