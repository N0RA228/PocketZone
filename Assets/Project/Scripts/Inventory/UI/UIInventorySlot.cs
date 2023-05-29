using InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIInventorySlot : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _textAmount;

    private InventorySlot _inventorySlot;
    private UIInventory _uIInventory;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(Click);
    }

    public void Display (InventorySlot inventorySlot, UIInventory uIInventory)
    {
        _inventorySlot = inventorySlot;
        _uIInventory = uIInventory;

        _image.sprite = _inventorySlot.item.Sprite;

        _textAmount.text = "";

        if (_inventorySlot.amount > 1)
        {
            _textAmount.text = _inventorySlot.amount.ToString();

            if(_inventorySlot.AmountMax > -1)
            {
                _textAmount.text += "/" + _inventorySlot.AmountMax.ToString();
            }
        }
    }

    public void Click ()
    {
        _uIInventory.ClickToSlot(this, _inventorySlot);
    }
}
