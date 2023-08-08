using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] int _bulletDamage = 1;
    [SerializeField] float _buletSpeed = 1;

    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(Vector2.up * _buletSpeed, ForceMode2D.Impulse);
        Destroy(this.gameObject, 1);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyController enemy))
        {
            _bulletDamage = (GameManager.instance.Score / 40) + 1;
            enemy.Damage(_bulletDamage);
            Destroy(this.gameObject);
        }
    }
}
