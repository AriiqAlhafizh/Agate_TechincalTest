using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private Rigidbody2D rb;

    private Vector2 direction = new Vector2(1f, 1f).normalized;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = Vector2.Reflect(direction, collision.contacts[0].normal);
    }
}
