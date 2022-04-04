using System;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private float _health = 100f;

    public event Action OnDestroy;

    void Update()
    {
        if (_health <= 0)
        {
            OnDestroy?.Invoke();
            Destroy(gameObject);
        }
    }

    public float Damage(float value)
    {
        if (_health < value)
        {
            var result = _health;
            _health = 0;
            return result;
        }

        _health -= value;
        return value;
    }
}
