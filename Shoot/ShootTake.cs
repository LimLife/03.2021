using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTake : MonoBehaviour
{
    #region PoolInctance
    [SerializeField]
    private PoolObject<ShootBullet> _bulletPool;
    [SerializeField]
    private ShootBullet _bullet;

    [Range(0, 10)]
    private int _poolCount;

    [SerializeField]
    private bool autoExpand;

    [SerializeField]
    private Transform _transformParent;
    #endregion 
    void Start()
    {
        _bulletPool = new PoolObject<ShootBullet>(_bullet, _poolCount, transform)           
        {               
            Expand = autoExpand,
        };
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PositionShooting();
        }
    }

    private void PositionShooting()
    {
        Vector3 pos = _transformParent.position;
        var pollobj = _bulletPool.GetFreeElement();
        pollobj.transform.position = pos;
    }

    private void Update()
    {
        Shoot();
    }
}
