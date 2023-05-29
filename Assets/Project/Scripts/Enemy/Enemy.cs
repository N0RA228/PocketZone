using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnDeadEvent;

    public void DeadInvoke()
    {
        OnDeadEvent?.Invoke(this);
    }
}
