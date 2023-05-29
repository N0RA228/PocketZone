using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField] private Image _image;

    private IHealth _health;

    public void SetHealth (IHealth health)
    {
        _health = health;
        _health.OnChangeHealthEvent += OnChangeHealth;

        _image.fillAmount = 1f;

        Display();
    }

    public void Display ()
    {
        _image.fillAmount = (float) _health.Value / _health.MaxValue;
    }

    private void OnChangeHealth(object sender)
    {
        Display();
    }
}
