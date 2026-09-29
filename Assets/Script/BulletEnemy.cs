using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] protected int damage = 1;
    [SerializeField] protected float speed = 20f;
    [SerializeField] protected float lifetime = 10f;
    [SerializeField] protected GameObject enemyBulllet;

    void Start()
    {
        Destroy(gameObject, lifetime);

    }

    void Update()
    {
        enemyBulllet.transform.Translate(Vector2.up * -speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
        
            Player _player = collision.GetComponent<Player>();
            if (_player != null)
            {
                _player.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        if (collision.CompareTag("Arme"))
        {
            print("treger inter");
            Arme arme = collision.GetComponent<Arme>();

            if (arme != null)
            {
                arme.TakeDamageEnemy(damage);
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("col inter");
    }
}
