using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler 
{

    [SerializeField] private Image _joystickBg;
    [SerializeField] private Image _joystick;

    private Vector2 _inputVector;

    public float Horizontal => _inputVector.x;
    public float Vertical => _inputVector.y;

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp (PointerEventData ped)
    {
        _inputVector = Vector2.zero;
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {

            pos.x = (pos.x / _joystickBg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / _joystickBg.rectTransform.sizeDelta.y);

            _inputVector = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1);
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;

            _joystick.rectTransform.anchoredPosition = new Vector2(_inputVector.x * (_joystick.rectTransform.sizeDelta.x), _inputVector.y * (_joystick.rectTransform.sizeDelta.y));

        }
    }
}
