using System;
using Atomic.Contexts;
using UnityEngine;

namespace FiguresGame
{
    [Serializable]
    public class Settings: IContextSystem

    {
        [SerializeField] private Color[] _colors;
        [SerializeField] private Sprite[] _sprites;
        
        public Color[] Colors => _colors;
        public Sprite[] Sprites => _sprites;
    }
}