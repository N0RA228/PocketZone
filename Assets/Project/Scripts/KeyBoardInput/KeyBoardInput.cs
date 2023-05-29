using UnityEngine;
using UnityEngine.EventSystems;

public class KeyBoardInput : MonoBehaviour
{
    [SerializeField] private GameObject _controllableObject;

    [Space]
    public bool active = true;
    
    private IMovable _controllable;
    private IShot _shot;

    public GameObject ControllableObject => _controllableObject;

    private bool _isMove;

    private void Awake()
    {
        if (_controllableObject == null)
            return;

        _controllable = _controllableObject.GetComponent<IMovable>();
        _shot = _controllableObject.GetComponent<IShot>();

    }

    public void SetControllable (IMovable controllable)
    {
        _controllable = controllable;
    }

    public void SetShot(IShot shot)
    {
        _shot = shot;
    }

    private void Update()
    {
        if (!active)
            return;


        if (_shot != null)
        {
            if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                _shot.Shot();
            }
        }
    }

    private void FixedUpdate()
    {
        if (!active)
            return;

        if (_controllable == null)
            return;

        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        if (direction.x != 0 || direction.y != 0 || _isMove)
        {
            _controllable.Move(direction, Time.fixedDeltaTime);

            _isMove = direction.x != 0 || direction.y != 0;
        } 
    }
}
