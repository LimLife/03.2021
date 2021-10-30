using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10;

    [SerializeField]
    private GameObject _prefabBullet;

    [SerializeField, Range(0f, 10f)]
    private float _timeLife;

    [SerializeField, Range(0f, 10f)]
    private float _timeReload;

    private void BulletDiraction()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void CheckTimeOut()
    {
        gameObject.SetActive(false);
    }

    private void Timer()
    {
        _timeLife -= Time.deltaTime;
        if (_timeLife < 0)
        {
            CheckTimeOut();
            _timeLife = _timeReload;
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.gameObject.CompareTag("Bonus"))
        {          
            gameObject.SetActive(false);          
        }
    }

    private void Update()
    {
        BulletDiraction();
        Timer();
    }
}
