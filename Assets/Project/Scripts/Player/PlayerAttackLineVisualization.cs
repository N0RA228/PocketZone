using UnityEngine;

public class PlayerAttackLineVisualization : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private DamageableDetecter _damageableDetecter;

    private void Update()
    {
        if (_damageableDetecter.Damageables.Count < 1)
        {
            _lineRenderer.enabled = false;
            return;
        }

        _lineRenderer.enabled = true;

        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _damageableDetecter.Damageables[0].Position);
    }
}
