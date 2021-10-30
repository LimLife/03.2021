using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject<T> where T : MonoBehaviour
{

    public T Prefab { get; }

    public bool Expand { get; set; }

    public Transform Container { get; }

    private List<T> _pool;

    public PoolObject( T prefab, int count)
    {
        Prefab = prefab;
        Create(count);
    }
    public PoolObject(T prefab, int count, Transform transform)
    {
        Prefab = prefab;
        Container = transform;
        Create(count);
    }

    private void Create(int count)
    {
        _pool = new List<T>();
        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }
    private T CreateObject(bool isExpand = false)
    {
        var createObj = UnityEngine.Object.Instantiate(Prefab, Container);
        createObj.gameObject.SetActive(isExpand);
        _pool.Add(createObj);
        return createObj;
    }
    public bool HasFreeElement(out T element)
    {
        foreach (var item in _pool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                element = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }
    public T GetFreeElement()
    {
        if (HasFreeElement(out var element))
        {
            return element;
        }
        if (Expand)
        {
            return CreateObject(true);
        }
        throw new Exception("No elemnt");
    }
}
