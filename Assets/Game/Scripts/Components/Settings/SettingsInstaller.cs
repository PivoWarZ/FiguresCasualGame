using System.Collections.Generic;
using Atomic.Entities;
using UnityEngine;

namespace FiguresGame
{
    public class SettingsInstaller: SceneEntityInstallerBase
    {
        [SerializeField] private Sprite[] _animals;
        [SerializeField] private List<SceneEntity> _prefabs;
        [SerializeField] private Color[] _colors;
        public override void Install(IEntity entity)
        {
            entity.AddAnimalImages(_animals);
            entity.AddPrefabs(_prefabs);
            entity.AddSpriteColors(_colors);
        }
    }
}