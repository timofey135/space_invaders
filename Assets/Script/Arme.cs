using UnityEngine;

public class Arme : MonoBehaviour
{
    [SerializeField] private int _healthArme;


    public void TakeDamageEnemy(int damage)
    {
        _healthArme -= damage;

        if (_healthArme <= 0)
        {
            DeathEnemy();
        }
    }

    public void DeathEnemy()
    {
        Debug.Log("контактArme");
        Destroy(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("col inter");
    }
}
