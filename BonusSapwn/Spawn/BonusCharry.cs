using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCharry : MonoBehaviour
{
    [SerializeField]
    private CharryBomus _bomusItem;

    private PoolObject<CharryBomus> _poolBouns;


    [SerializeField]
    private int _poolCount = 0;
    [SerializeField]
    private bool _autoExpand;


    [Header("Postion +X"), Range(0, 20), SerializeField]
    private float _positionXPlus;
    [Header("Postion -X"), Range(0, -20), SerializeField]
    private float _positionXMainus;


    [SerializeField, Range(0, 20)]
    private float _timeSpawn;
    [SerializeField, Range(0, 20)]
    private float _timeSpawnReload;



    [Header("Spawn Position Y"), Range(-40, 50), SerializeField]
    private float _ySpawnPosotion;
    private void Start()
    {

        _poolBouns = new PoolObject<CharryBomus>(_bomusItem, _poolCount)
        {
            Expand = _autoExpand
        };
    }

    private void Timer()
    {
        _timeSpawn -= Time.deltaTime;
        if (_timeSpawn < 0)
        {
            CreateBonusPrehfab();
            _timeSpawn = _timeSpawnReload;
        }
    }

    private void CreateBonusPrehfab()
    {
        var objectPostion = new Vector2(Random.Range(_positionXMainus, _positionXPlus), _ySpawnPosotion);
        var obj = _poolBouns.GetFreeElement();
        obj.transform.position = objectPostion;
    }

    private void Update()
    {
        Timer();
    }
}
