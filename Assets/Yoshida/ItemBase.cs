using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    protected abstract void ItemGet();
    Rigidbody2D _rb;

    void Start()
    {
        Destroy(this.gameObject, 3);
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _rb.velocity = Vector2.down * 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ItemGet();
            Destroy(this.gameObject);
        }
    }
}
