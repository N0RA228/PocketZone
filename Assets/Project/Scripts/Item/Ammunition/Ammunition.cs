using System;
using UnityEngine;

namespace ItemSystem
{
    [Serializable]
    public class Ammunition : Item
    {
        public override Type Type => GetType();

        public Ammunition(string id, string name, Sprite sprite, int maxInSlot = -1) : base(id, name, sprite, maxInSlot)
        {

        }
    }
}