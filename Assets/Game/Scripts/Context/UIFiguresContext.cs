using System;
using Atomic.Contexts;
using FiguresGame;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Scripts.Context
{
    [Serializable]
    public sealed class UIFiguresContext: IContextInit, IContextEnable, IContextDispose
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _winscreen;
        [SerializeField] private Button _loosescreen;
        [SerializeField] private Button _refreshButton;
        private ActiveEntitiesBehavior _activeEntities;
        private SpawnerInstaller _spawner;
        
        public void Init(IContext context)
        {
            _activeEntities = context.GetActivesEntities();
            _spawner = context.GetSpawner();
        }
        
        [Button]
        private void Refresh()
        {
            _activeEntities.HideFigures();
            _activeEntities.TimerStart();
        }

        public void Enable(IContext context)
        {
            context.GetOnLoose().Subscribe(ShowLooseScreen);

            _activeEntities.ActiveEntitiesCount.Subscribe(ShowWinScreen);
            
            _refreshButton.onClick.AddListener(Refresh);
            _winscreen.onClick.AddListener(Reload);
            _loosescreen.onClick.AddListener(Reload);
            _startButton.onClick.AddListener(StartGame);
            
            _startButton.gameObject.SetActive(true);
        }

        private void StartGame()
        {
            _spawner.Spawn(_spawner.SpawnCount);
            _startButton.gameObject.SetActive(false);
            _refreshButton.gameObject.SetActive(true);
        }

        private void Reload()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        private void ShowLooseScreen()
        {
            _loosescreen.gameObject.SetActive(true);
            _refreshButton.gameObject.SetActive(false);
        }

        private void ShowWinScreen(int count)
        {
            if (count <= 0)
            {
                _winscreen.gameObject.SetActive(true);
            }
        }

        void IContextDispose.Dispose(IContext context)
        {
            context.GetOnLoose().Unsubscribe(ShowLooseScreen);
            
            _refreshButton.onClick.RemoveListener(Refresh);
            _loosescreen.onClick.RemoveListener(Reload);
            _winscreen.onClick.RemoveListener(Reload);
            _startButton.onClick.RemoveListener(StartGame);
            _activeEntities.ActiveEntitiesCount.Unsubscribe(ShowWinScreen);
        }
    }
}