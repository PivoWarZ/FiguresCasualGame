using System;
using Atomic.Contexts;
using UnityEngine;
using Atomic.Entities;
using Unity.VisualScripting;
using Random = UnityEngine.Random;
using Timer = Atomic.Elements.Timer;

namespace FiguresGame
{
    public class SpawnerBehavior: IContextInit, IContextEnable, IContextUpdate, IContextDispose
    {
        private SpawnerInstaller _spawner;
        private Transform _figuresContainer;
        private Timer _timer;
        private int _count;

        void IContextInit.Init(IContext context)
        {
            _spawner = context.GetSpawner();
            _timer = context.GetSpawner().Timer;
            _figuresContainer = context.GetFiguresContainer();
        }

        void IContextEnable.Enable(IContext context)
        {
            _timer.OnEnded += Spawn;
            _spawner.OnSpawn += SetCount;
        }

        private void SetCount(int count)
        {
            Debug.Log("SetCount: " + count);
            _count = count;
            _timer.Start();
        }

        public void Update(IContext context, float deltaTime)
        {
            _timer.Tick(deltaTime);
        }
        
        private void Spawn()
        {
            var index = 0;
            
            while (_count > 0)
            {
                var positionIndex = (index + 1) % _spawner.SpawnPoints.Count;
                IEntity entity = SceneEntity.Instantiate(_spawner.Prefab, _spawner.SpawnPoints[positionIndex].position, Quaternion.identity, _figuresContainer);
                _spawner.OnEntitySpawned.Invoke(entity);
                index++;
                _count--;
                //Debug.Log($"Spawn count: {_count}  {_figuresContainer.name}");
                Debug.Log("Index: " + positionIndex);
            }

            _timer.Stop();
        }

        private Vector3 GetRandomPosition()
        {
            var value = Random.Range(0, _spawner.SpawnPoints.Count);
            return _spawner.SpawnPoints[value].position;
        }

        void IContextDispose.Dispose(IContext context)
        {
            _timer.OnEnded -= Spawn;
           _spawner.OnSpawn -= SetCount;
        }
    }
}