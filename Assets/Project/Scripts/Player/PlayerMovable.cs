using UnityEngine;

public class PlayerMovable : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;
    
    [Space]
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private Flip _flip;

    private bool _isMove;
    private Vector3 _direction;


    public float Speed => _speed;
    public bool IsMove => _isMove;
    public Vector3 Direction => _direction;

    
    public void Init()
    {
        _direction = Vector3.right;
    }

    public void Move(Vector2 direction, float deltaTime)
    {
        if ((direction.x != 0 || direction.y != 0))
        {
            if (!_isMove)
            {
                _isMove = true;
                _playerAnimator.PlayRunAnimation();
            }

            _direction = direction;
        }
        else if (_isMove)
        {
            _isMove = false;
            _playerAnimator.PlayIdleAnimation();
        }

        if (direction.x > 0)
        {
            _flip.flipX = false;
        }
        else if(direction.x < 0)
        {
            _flip.flipX = true;
        }

        transform.Translate(direction * _speed * deltaTime);
    }
}
