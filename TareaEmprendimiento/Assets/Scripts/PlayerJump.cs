using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float Velocidad = 5f;
    public float FuerzaSalto = 10f;
    public float LongitudRaycast = 0.1f;
    public LayerMask CapaSuelo;
    private bool Ensuelo;
    private Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, LongitudRaycast, CapaSuelo);
        Ensuelo = hit.collider != null;

        if (Ensuelo && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, FuerzaSalto), ForceMode2D.Impulse);
        }

        animator.SetBool("Ensuelo", Ensuelo);
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * LongitudRaycast);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstacle")
        {
            Destroy(gameObject);
            // GameManager Set Game Over
        }
    }

}