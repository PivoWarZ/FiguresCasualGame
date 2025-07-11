﻿using System;
using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FiguresGame
{
    public sealed class SetFiguresBehavior: IContextInit, IContextEnable, IContextDispose
    {
        private readonly List<FiguresStruct> _struct = new();
        private int _count;
        private int _poolSize;
        private Color[] _colors;
        private Sprite[] _sprites;
        private Color _setColor;
        private Sprite _setSprite;
        private int _objectType;
        
        public void Init(IContext context)
        {
            _poolSize = context.GetSpawner().PoolSize;
            _colors = context.GetSettings().Colors;
            _sprites = context.GetSettings().Sprites;
            _setColor = _colors[Random.Range(0, _colors.Length - 1)];
            _setSprite = _sprites[Random.Range(0, _sprites.Length - 1)];
        }
        
        void IContextEnable.Enable(IContext context)
        {
            context.GetSpawner().OnEntitySpawned.Subscribe(SetEntity);
        }

        private void SetEntity(IEntity entity)
        {
            if (_count % _poolSize == 0)
            {
                _setColor = _colors[Random.Range(0, _colors.Length - 1)];
                _setSprite = _sprites[Random.Range(0, _sprites.Length - 1)];
                var figure = entity.GetColorSpriteRenderer().sprite.ToString();
                FiguresStruct newFigure = GetFigure(figure, _setSprite.ToString(), _setColor);
                bool isUnique = UniquenessCheck(newFigure);
                
                if (!isUnique)
                {   
                    SetEntity(entity);
                    Debug.Log($"<color=green>REPEAT!</color>");
                    return;
                }
                
                _objectType++;
                _struct.Add(newFigure);
            }

            entity.GetObjectType().Value = _objectType;
            entity.GetColorSpriteRenderer().color = _setColor;
            entity.GetAnimalSpriteRenderer().sprite = _setSprite;
            _count++;
        }

        private bool UniquenessCheck(FiguresStruct newFigure)
        {
            foreach (var figure in _struct)
            {
                if (figure.Figure == newFigure.Figure
                    && figure.Animal == newFigure.Animal
                    && figure.Color == newFigure.Color)
                {
                    return false;
                }
            }
            
            return true;
        }

        private FiguresStruct GetFigure(string figure, string animal, Color color)
        {
            var newFigure = new FiguresStruct();
            newFigure.Figure = figure;
            newFigure.Animal = animal;
            newFigure.Color = color;
            return newFigure;
        }

        void IContextDispose.Dispose(IContext context)
        {
            context.GetSpawner().OnEntitySpawned.Unsubscribe(SetEntity);
        }
    }
}