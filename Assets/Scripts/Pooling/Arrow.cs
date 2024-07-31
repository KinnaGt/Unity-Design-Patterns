using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    public float lifetime = 5f;
    private bool hasCollided;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        hasCollided = false;
        Invoke("Deactivate", lifetime);
    }

    void Update()
    {
        if (!hasCollided && rb.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg - 90f; // Ajusta el ángulo para que la punta apunte en la dirección correcta
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rb.velocity = direction * force;
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            hasCollided = true; // Marcar que la flecha ha colisionado
        }
    }
}
