using Atomic.Contexts;
using UnityEngine;

namespace FiguresGame
{
    public class FiguresGameContext: SceneContextInstallerBase
    {
        [SerializeField] private ServiceLocator _serviceLocator;
        [SerializeField] private SpawnerInstaller _spawner;
        [SerializeField] private Settings _settings;
        public override void Install(IContext context)
        {
            _serviceLocator.Install(context);
            _spawner.Install(context);
            
            context.AddSpawner(_spawner);
            context.AddSettings(_settings);
        }
    }
}