using Atomic.Contexts;
using UnityEngine;

namespace FiguresGame
{
    public class FiguresGameContext: SceneContextInstallerBase
    {
        [SerializeField] private ServiceLocator _serviceLocator;
        [SerializeField] private SpawnerInstaller _spawner;
        public override void Install(IContext context)
        {
            _serviceLocator.Install(context);
            _spawner.Install(context);
            Debug.Log("FIguresGameContext Install");
            context.AddSpawner(_spawner);
        }
    }
}