using UnityEngine;

public class Arrow : MonoBehaviour
{
    public ScoreController scoreController;
    private Rigidbody2D rb;
    public float lifetime = 5f;

    [SerializeField]
    private bool hasCollided;

    void Start()
    {
        scoreController = FindObjectOfType<ScoreController>();
    }

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
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg - 90f;
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
        if (collision.gameObject.CompareTag("Wall")) {
            FreezePosition();
         }
        else if (collision.gameObject.CompareTag("Enemy") && scoreController != null)
        {
            scoreController.AddPoints(1);
            FreezePosition();
        }
    }

    void FreezePosition()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        rb.angularVelocity = 0f;
        hasCollided = true;
    }
}
