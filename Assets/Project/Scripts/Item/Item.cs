using System;
using UnityEngine;

namespace ItemSystem
{
    [Serializable]
    public abstract class Item
    {
        private string _id;
        private string _name;
        private Sprite _sprite;
        private int _maxInSlot;

        public string ID => _id;
        public virtual Type Type => GetType();
        public string Name => _name;
        public Sprite Sprite => _sprite;
        public int MaxInSlot => _maxInSlot;

        protected Item(string id, string name, Sprite sprite, int maxInSlot = -1)
        {
            _id = id;
            _name = name;
            _sprite = sprite;
            _maxInSlot = maxInSlot;
        }
    }
}