using Atomic.Contexts;
using Atomic.Entities;
using FiguresGame;
using UnityEngine;

namespace Game.Scripts.Components
{
    public sealed class InputBehavior: IContextUpdate
    {
        private const int LEFT_BUTTON = 0;
        public void Update(IContext context, float deltaTime)
        {
            if (Input.GetMouseButtonDown(LEFT_BUTTON))
            {
                Vector3 mouseScreenPosition = Input.mousePosition;
                
                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
                Vector2 origin = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
                
                Vector2 direction = Vector2.up;
                RaycastHit2D hit = Physics2D.Raycast(origin, direction, 0.2f);
                
                
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.TryGetEntity(out IEntity detectedEntity))
                    {
                        detectedEntity.GetOnEntityClick()?.Invoke(detectedEntity);
                    }
                }
            }
        }
    }
}