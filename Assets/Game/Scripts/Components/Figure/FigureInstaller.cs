using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FiguresGame
{
    public class FigureInstaller: SceneEntityInstallerBase
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private SpriteRenderer _animalSpriteRenderer;
        [ShowInInspector] private int _objectType;
      
        public override void Install(IEntity entity)
        {
            entity.AddSpriteRenderer(_spriteRenderer);
            entity.AddAnimalSpriteRenderer(_animalSpriteRenderer);
            entity.AddObjectType(_objectType);
        }
    }
}