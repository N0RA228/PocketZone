using UnityEngine;

public class EnemyMovable : MonoBehaviour
{
    [SerializeField] private Flip _flip;

    public void MoveTo(Vector2 position, float speed, float delta)
    {
        if (position.x > transform.position.x)
        {
            _flip.flipX = false;
        }
        else if (position.x < transform.position.x)
        {
            _flip.flipX = true;
        }

        transform.position = Vector2.MoveTowards(transform.position, position, speed * delta);
    }
}
