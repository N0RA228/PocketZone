using UnityEngine;

namespace ItemSystem
{
    public abstract class ItemConfig : ScriptableObject
    {
        [SerializeField] protected string _name;
        [SerializeField] protected Sprite _sprite;
        [SerializeField] protected int _maxInSlot = -1;

        public string ID => name;

        public abstract Item GetItem();
    }
}