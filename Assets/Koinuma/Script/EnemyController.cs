using TMPro;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _hp;
    [SerializeField] int _hpAmplification;
    [SerializeField] TextMeshProUGUI _meshPro;
    Rigidbody2D _rb;

    private void Start()
    {
        Destroy(gameObject, 5);
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.down * _speed;
        _hp *= 1 + (int)Time.time / _hpAmplification;
        _meshPro.text = _hp.ToString();
    }

    public void Damage(int damage)
    {
        _hp -= damage;
        _meshPro.text = _hp.ToString();
    }
}
