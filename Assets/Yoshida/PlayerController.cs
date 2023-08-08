using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _shotDelay = 0.5f;
    [SerializeField] GameObject _bulletPrefab;

    Rigidbody2D _rb;

    float _xInput = 0;

    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public float ShotDeley { get => _shotDelay; set => _shotDelay = value; }
    public float XInput => _xInput;

    public static PlayerController Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ShootDelay());
    }

    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.instance.GameOver();
            Destroy(this);
        }
    }

    void Move()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_moveSpeed * _xInput, _rb.velocity.y);
    }

    IEnumerator ShootDelay()
    {
        Instantiate(_bulletPrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.8f), Quaternion.identity);
        yield return new WaitForSeconds(_shotDelay);
        StartCoroutine(ShootDelay());
    }
}
