using UnityEngine;
using UnityEngine.UI;
public class CharryBomus : MonoBehaviour
{
    private float _speed = 10;
    private int _damage = 6;

    [SerializeField]
    private Scrollbar _hitPoint;

    [SerializeField, Range(0, -60)]
    private float _positionOutRangeGame = -48;
    private void Start()
    {
        _hitPoint.size = 1;
        _hitPoint.gameObject.SetActive(false);
    }
    private void Move()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
        if (transform.position.y < _positionOutRangeGame)
        {
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ShootBullet>())
        {
            _hitPoint.gameObject.SetActive(true);
            _hitPoint.size -= 0.2f;
            if (_hitPoint.size <= 0)
            {
                EventHandler.ScoreRank(2);
                gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.GetComponent<Player>())
        {
            EventHandler.TakeDamge(this, _damage);
        }
    }
}
