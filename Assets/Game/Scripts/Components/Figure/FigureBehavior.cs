using Atomic.Entities;
using UnityEngine;

namespace FiguresGame
{
    public class FigureBehavior: IEntityUpdate, IEntityInit, IEntityDispose
    {
        private Vector3 _mousePosition;
        private Ray _ray;
        private RaycastHit _hit;
        private Vector3 _position;
        private bool _isClicked;
        
        public void Init(IEntity entity)
        {
           _isClicked = false;
        }
        
        void IEntityUpdate.OnUpdate(IEntity entity, float deltaTime)
        {
            if (Input.GetMouseButtonDown(0) && !_isClicked)
            {
                _isClicked = true;
                Debug.Log(_isClicked);
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), 
                    Vector2.zero, Mathf.Infinity, 3 << LayerMask.NameToLayer("Figures"));
                
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.gameObject.name);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("MouseUp");
                _isClicked = false;
            }

        }

        public void Dispose(IEntity entity)
        {
            entity.GetOnEntityDelete().Invoke(entity);
        }



    }
}