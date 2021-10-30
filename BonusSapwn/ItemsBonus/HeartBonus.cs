using UnityEngine;

public class HeartBonus : MonoBehaviour
{
    private float _speed = 10f;
    private int _halfChange = 5;

    [SerializeField,Range(0,-60)]
    private float _positionOutRangeGame = -48;
    private void Move()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
        if (transform.position.x < _positionOutRangeGame)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            EventHandler.TakeDamge(this,-_halfChange);
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        Move();
    }

}
