using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FiguresGame
{
    public class FigureInstaller: SceneEntityInstallerBase
    { 
        public Event<IEntity> OnEntityDeleted;
        public Event<IEntity> OnEntityClick;

        [SerializeField] private Transform _entityTransform;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private SpriteRenderer _animalSpriteRenderer;
        [ShowInInspector] ReactiveVariable<int> _objectType = new();
      
        public override void Install(IEntity entity)
        {
            entity.AddOnEntityClick(OnEntityClick);
            entity.AddEntityTransform(_entityTransform);
            entity.AddOnEntityDelete(OnEntityDeleted);
            entity.AddSpriteRenderer(_spriteRenderer);
            entity.AddAnimalSpriteRenderer(_animalSpriteRenderer);
            entity.AddObjectType(_objectType);
            
            entity.AddBehaviour(new FigureBehavior());
        }
    }
}