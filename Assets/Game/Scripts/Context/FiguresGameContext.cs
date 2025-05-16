using Atomic.Contexts;
using Game.Scripts.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace FiguresGame
{
    public class FiguresGameContext: SceneContextInstallerBase
    {
        [SerializeField] private ServiceLocator _serviceLocator;
        [SerializeField] private SpawnerInstaller _spawner;
        [SerializeField] private Settings _settings;
        [SerializeField] private Bar _bar;
        public override void Install(IContext context)
        {
            context.AddSpawner(_spawner);
            context.AddSettings(_settings);
            
            _serviceLocator.Install(context);
            _spawner.Install(context);
            _bar.Install(context);

            context.AddSystem(new InputBehavior());

        }
    }
}