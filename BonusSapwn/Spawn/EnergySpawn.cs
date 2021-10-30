using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySpawn : MonoBehaviour
{
    [SerializeField]
    private EnergyBonus _bonus;  

    private PoolObject<EnergyBonus> _poolEnergy;

    [SerializeField]
    private int _countPool;

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
        _poolEnergy = new PoolObject<EnergyBonus>(_bonus, _countPool)
        {
            Expand = _autoExpand
        };
    }

    private void SpawnPrefab()
    {
        var objectPostion = new Vector2(Random.Range(_positionXMainus, _positionXPlus), _ySpawnPosotion);
        var obj = _poolEnergy.GetFreeElement();
        obj.transform.position = objectPostion;
    }
    private void Timer()
    {
        _timeSpawn -= Time.deltaTime;
        if (_timeSpawn < 0)
        {
            SpawnPrefab();
            _timeSpawn = _timeSpawnReload;
        }
    }
    private void Update()
    {
        Timer();
    }

}
