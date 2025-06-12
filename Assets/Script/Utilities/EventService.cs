using System;
using UnityEngine;
public class EventService
{
    public EventController<ProjectileType, Vector3> OnShootProjectile { get; private set; }
    public EventController<DefenderType, Vector3, bool> OnPlaceDefender { get; private set; }
    public EventController<AttackerType, Slot, AttackerController> OnSpawnAttacker { get; private set; }


    public EventService()
    {
        OnShootProjectile = new EventController<ProjectileType, Vector3>();
        OnPlaceDefender = new EventController<DefenderType, Vector3, bool>();
        OnSpawnAttacker = new EventController<AttackerType, Slot, AttackerController>();
    }
}
public class EventController<T, K, R>
{
    private Func<T, K, R> baseEvent;

    public R InvokeEvent(T type, K type2) => baseEvent != null ? baseEvent(type, type2) : default;

    public void AddListener(Func<T, K, R> listener) => baseEvent += listener;

    public void RemoveListener(Func<T, K, R> listener) => baseEvent -= listener;
}

public class EventController<T, K>
{
    public event Action<T, K> baseEvent;
    public void InvokeEvent(T type, K type2) => baseEvent?.Invoke(type, type2);
    public void AddListener(Action<T, K> listener) => baseEvent += listener;
    public void RemoveListener(Action<T, K> listener) => baseEvent -= listener;
}

public class EventController<T>
{
    public event Action<T> baseEvent;
    public void InvokeEvent(T type) => baseEvent?.Invoke(type);
    public void AddListener(Action<T> listener) => baseEvent += listener;
    public void RemoveListener(Action<T> listener) => baseEvent -= listener;
}


