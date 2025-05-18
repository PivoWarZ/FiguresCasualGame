using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace FiguresGame
{
    public class FigureInstaller: SceneEntityInstallerBase
    { 
        public Event<IEntity> OnEntityClick;
        public Event<IEntity> OnBarPosition;
        public Event<IEntity> OnEntityDestroy;

        [SerializeField] private Transform _entityTransform;
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private SpriteRenderer _colorSpriteRenderer;
        [SerializeField] private SpriteRenderer _animalSpriteRenderer;
        [SerializeField] private Collider2D _figureCollider;
        [ShowInInspector] ReactiveVariable<int> _id = new();
        [ShowInInspector] ReactiveVariable<int> _objectType = new();
      
        public override void Install(IEntity entity)
        {
            entity.AddOnEntityClick(OnEntityClick);
            entity.AddOnBarPosition(OnBarPosition);
            entity.AddOnEntityDestroy(OnEntityDestroy);
            entity.AddEntityTransform(_entityTransform);
            entity.AddFigureCollider(_figureCollider);
            entity.AddColorSpriteRenderer(_colorSpriteRenderer);
            entity.AddAnimalSpriteRenderer(_animalSpriteRenderer);
            entity.AddObjectType(_objectType);
            entity.AddID(_id);
            
            _moveInstaller.Install(entity);
            
            entity.AddBehaviour(new MoveToPointBehavior());
        }
    }
}