using InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryAboutItem : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _textDescription;
    [SerializeField] private TextMeshProUGUI _textAmount;

    [Space]
    [SerializeField] private Transform _aboutPanel;

    private Inventory _inventory;
    private InventorySlot _slot;

    public void Display (InventorySlot slot, Inventory inventory)
    {
        Close();

        _inventory = inventory;
        _slot = slot;

        _slot.OnChangeEvent += Display;
        _slot.OnDeleteSlotEvent += Close;

        Display();
    }

    public void Close()
    {
        Hide();

        if(_slot != null)
        {
            _slot.OnChangeEvent -= Display;
            _slot.OnDeleteSlotEvent -= Close;
        }

        _inventory = null;
        _slot = null;
    }

    public void DeleteItem ()
    {
        if(_slot != null && _inventory  != null)
        {
            _inventory.Delete(_slot.item);
        }
    }

    private void Display ()
    {
        _icon.sprite = _slot.item.Sprite;

        _textDescription.text = _slot.item.Name;

        _textAmount.text = "";

        if (_slot.amount > 1)
        {
            _textAmount.text = _slot.amount.ToString();

            if (_slot.AmountMax > -1)
            {
                _textAmount.text += "/" + _slot.AmountMax.ToString();
            }
        }

        Show();
    }

    private void Show ()
    {
        _aboutPanel.gameObject.SetActive(true);
    }

    private void Hide()
    {
        _aboutPanel.gameObject.SetActive(false);
    }
}
