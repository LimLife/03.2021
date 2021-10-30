using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBonus : MonoBehaviour
{
    private float _speed = 10;
    private float _speedBuff = 5;
    [SerializeField, Range(0, -60)]
    private float _positionOutRangeGame = -48;
    private void Move()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
        if (transform.position.y < _positionOutRangeGame)
        {
            gameObject.SetActive(false);
        }
    }  
    void Update()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            EventHandler.BuffCharacter(this, _speedBuff);
            gameObject.SetActive(false);
        }      
    }
    
}
