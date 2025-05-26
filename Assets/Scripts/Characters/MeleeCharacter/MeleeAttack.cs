using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemigo golpeado: " + collision.name);
            // Aplicar daño o efectos
            // collision.GetComponent<Enemy>()?.TakeDamage(10);
        }
    }
}
