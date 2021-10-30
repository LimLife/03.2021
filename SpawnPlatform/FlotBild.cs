using System.Collections;
using UnityEngine;

public class FlotBild : MonoBehaviour
{
    #region Pool Object

    [SerializeField]
    private int pool;

    [SerializeField]
    private bool autoExpand = false;
    #endregion
    
    #region Determination value the spawn

    [SerializeField,Range(-28f,0)]
    private float _minSpereding = -5f;

    [SerializeField,Range(0f,28f)]
    private float _maxSpereding = 5f;

    [SerializeField,Range(-10,58)]
    private float _posYSpawn;

    [SerializeField, Range(0, 20)]
    private float _timeSpawn;
    [SerializeField, Range(0, 20)]
    private float _timeSpawnReload;
    #endregion

    [SerializeField]
    private FloatMove _object;

    private PoolObject<FloatMove> _poolObject;

    private void Start()
    {       
        _poolObject = new PoolObject<FloatMove>(_object, pool,transform)
        { 
            Expand = autoExpand 
        };       
    } 
    private void Timer()
    {
        _timeSpawn -= Time.deltaTime;
        if (_timeSpawn < 0)
        {
            CretePrefab();
            _timeSpawn = _timeSpawnReload;
        }
    }
    
    private void CretePrefab()
    {
        var objectSPostion = new Vector3(Random.Range(_minSpereding,_maxSpereding), _posYSpawn,0);
        var obj = _poolObject.GetFreeElement();
        obj.transform.position = objectSPostion;
    }

    private void Update()
    {
        Timer();
    }
}
