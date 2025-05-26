using UnityEngine;

public class RangedCharacterController : CharacterControllerBase
{
    [Header("Ranged Attack")]
    [SerializeField] private GameObject arrowPrefab; // Prefab de la flecha
    [SerializeField] private Transform firePoint;    // Posición de disparo

    protected override void Attack()
    {
        // Solo activa la animación, la flecha se lanza desde el Animation Event
        animator.SetTrigger("isAttacking");
    }

    // Este método será llamado desde un Animation Event en attack.anim
    public void ShootArrow()
    {
        if (arrowPrefab != null && firePoint != null)
        {
            // Instancia la flecha y ajusta su dirección
            GameObject arrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);
            arrow.transform.right = spriteRenderer.flipX ? Vector2.left : Vector2.right;
        }
        else
        {
            Debug.LogWarning("Falta asignar el prefab de la flecha o el FirePoint");
        }
    }
}
