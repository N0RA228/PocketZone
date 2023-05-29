using UnityEngine;

namespace ItemSystem
{
    public class ItemMono : MonoBehaviour
    {
        [SerializeField] private ItemConfig _config;

        [Space]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private Item _item;


        private void Awake()
        {
            if (_config != null)
                _item = _config.GetItem();

            Display();
        }

        public void SetItem(ItemConfig itemConfig)
        {
            SetItem(itemConfig.GetItem());
        }

        public void SetItem (Item item)
        {
            _item = item;

            Display();
        }

        private void Display ()
        {
            _spriteRenderer.sprite = _item.Sprite;
        }

        private void Clear()
        {
            _spriteRenderer.sprite = null;
        }

        public Item GetItem()
        {
            return _item;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

#if (UNITY_EDITOR)

        private void OnValidate()
        {
            if (_config != null)
                _spriteRenderer.sprite = _config.GetItem().Sprite;
            else
                Clear();
        }

#endif
    }
}