using UnityEngine;

public class GUIHealth : MonoBehaviour
{
    [SerializeField] private Transform _transformFillImageScale;
    [SerializeField] private Transform _visualBar;

    private IHealth _health;

    public void SetHealth(IHealth health)
    {
        _health = health;
        _health.OnChangeHealthEvent += OnChangeHealth;

        _transformFillImageScale.localScale = new Vector3(1f, _transformFillImageScale.localScale.y, _transformFillImageScale.localScale.z);

        Display();
    }

    public void Display()
    {
        float fill = (float) _health.Value / _health.MaxValue;
        _transformFillImageScale.localScale = new Vector3 (fill, _transformFillImageScale.localScale.y, _transformFillImageScale.localScale.z);

        if(fill == 1f)
            _visualBar.gameObject.SetActive(false);
        else
            _visualBar.gameObject.SetActive(true);
    }

    private void OnChangeHealth(object sender)
    {
        Display();
    }
}
