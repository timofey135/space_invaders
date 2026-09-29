using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected int damage = 1;
    [SerializeField] protected float speed = 20f;
    [SerializeField] protected float lifetime = 10f;

    void Start()
    {
        Destroy(gameObject, lifetime);

    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponentInParent<Enemy>();
        Debug.Log("тест");

        if (enemy != null)
        {
            Debug.Log("Попал во врага!");
            enemy.TakeDamageEnemy(damage);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Arme"))
        {
            print("treger inter");
            Arme arme = collision.GetComponent<Arme>();

            if (arme != null)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("col inter");
    }
}
