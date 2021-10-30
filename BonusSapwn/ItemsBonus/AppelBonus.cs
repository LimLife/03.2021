using System;
using UnityEngine;
using UnityEngine.UI;

public class AppelBonus : MonoBehaviour
{
    [SerializeField]
    private Scrollbar _HitPoint;   
    private float _speed = 10;
    private int _damage = 10;
    [SerializeField,Range(0,-60)]
    private float _positionOutRangeGame = -48;
    private void Start()
    {
        _HitPoint.size = 1;
        _HitPoint.gameObject.SetActive(false);
    }
    private void Move()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
        if (transform.position.y < _positionOutRangeGame)
        {
            gameObject.SetActive(false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ShootBullet>())
        {
            _HitPoint.gameObject.SetActive(true);
            _HitPoint.size -= 0.2f;
            if (_HitPoint.size <= 0)
            {
                EventHandler.ScoreRank(1);
                gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.GetComponent<Player>())
        {
            EventHandler.TakeDamge(this, _damage);
        }
    }
    private void Update()
    {
        Move();
       
    }
}
