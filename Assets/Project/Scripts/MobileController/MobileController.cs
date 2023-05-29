using UnityEngine;
using UnityEngine.UI;

public class MobileController : MonoBehaviour
{
    [SerializeField] private GameObject _controllableObject;

    [Space]
    [SerializeField] private Button _button;
    [SerializeField] private UIJoystick _joystick;
    
    public bool active = true;


    private IMovable _controllable;
    private IShot _shot;

    public GameObject ControllableObject => _controllableObject;

    private bool _isMove;

    private void Awake()
    {
        _button.onClick.AddListener(ShotButtonClick);


        if (_controllableObject == null)
            return;

        _controllable = _controllableObject.GetComponent<IMovable>();
        _shot = _controllableObject.GetComponent<IShot>();
    }

    public void SetControllable(IMovable controllable)
    {
        _controllable = controllable;
    }

    public void SetShot(IShot shot)
    {
        _shot = shot;
    }

    private void ShotButtonClick()
    {
        if (!active)
            return;

        if (_shot == null)
            return;

        _shot.Shot();
    }

    private void FixedUpdate()
    {
        if (!active)
            return;

        if (_controllable == null)
            return;

        Vector2 direction = new Vector2(_joystick.Horizontal, _joystick.Vertical);

        if(direction.x != 0 || direction.y != 0 || _isMove)
        {
            _controllable.Move(direction, Time.fixedDeltaTime);

            _isMove = direction.x != 0 || direction.y != 0;
        }
        
    }
}
