using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IPlayer
{
    //Split on part
    [Header("Propties Player")]
    #region Properties Player

    [SerializeField]
    private uint MultiplicationMoveDiraction;

    [SerializeField, Range(0f, 50f)]
    private float _speed;

    private bool _isCheckGround;

    [SerializeField]
    private float _jumpForce;

    private Vector2 _moveDearaction = Vector2.right.normalized;

    private float _hitPoint = 100;

    private int _startScore = 5;

    private float _buffTime = 5f;

    #endregion

    #region Components

    [SerializeField]
    private GameObject _prefabPlayer;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private FixedJoystick _joystick;

    [SerializeField]
    private Scrollbar _hitPointValue;
    #endregion

    #region TextRander
    [SerializeField]
    private Text _textBonus;

    [SerializeField]
    private Text _textTimer;
    
    private const string _formatBonus = "Bonus : ";
    private const string _formatTimer = "Timer : ";

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        _hitPointValue.size = 1;
        _hitPointValue.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        EventHandler.Hit += OnHit;
        EventHandler.BuffChange += OnCharacterBuff;
    }

    private void OnDisable()
    {
        EventHandler.Hit -= OnHit;
        EventHandler.BuffChange -= OnCharacterBuff;
    }

    private void OnCharacterBuff(object sender, float speedBuffValue)
    {
        float basebuffTime = _buffTime;
        float baseSpeed = _speed;
        _speed += speedBuffValue;
        DispalyBonus(_textBonus, _formatBonus, _speed);
        if (_speed != baseSpeed)
        {
            StartCoroutine(BuffTimerEnding(_buffTime, baseSpeed, basebuffTime));
        }
    }

    private IEnumerator BuffTimerEnding(float time, float speed, float timing)
    {
        while (time >= 0)
        {
            time -= 0.1f;
            DispalyBonus(_textTimer, _formatTimer, time);
            yield return new WaitForSeconds(0.1f);
            if (time <= 0)
            {
                DispalyBonus(_textTimer, _formatTimer, 0);
                _speed = speed;
                _buffTime = timing;
                DispalyBonus(_textBonus, _formatBonus, _speed);
                yield break;
            }
        }
    }

    private void DispalyBonus(Text text, string format, float bonus)
    {
        text.text = $"{format}{bonus.ToString("F" + 1)}";
    }

    private void OnHit(object sender, int damage)
    {
        _hitPoint -= damage;       
        if (_hitPoint != 100)
        {
            _hitPointValue.gameObject.SetActive(true);
            _hitPointValue.size -= (_hitPoint - (damage * 0.01f)); //20 => 0.01 == 0.2
            if (_hitPoint <= 0)
            {
                gameObject.SetActive(false);
                Debug.Log("Caharacter dead");
            }
        }
        if (_hitPoint == 100 || _hitPoint> 100)
        {
            _hitPoint = 100; // change base halfPoint
            _hitPointValue.gameObject.SetActive(false);
        }
    }

    public void Move()
    {
        rb.AddForce((_moveDearaction * _joystick.Direction * MultiplicationMoveDiraction) * _speed, ForceMode2D.Force);
    }

    public void Jump()
    {
        if (_isCheckGround == true)
        {
            EventHandler.ScoreRank(_startScore);
            rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isCheckGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<FloatMove>())
        {
            _isCheckGround = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

}
