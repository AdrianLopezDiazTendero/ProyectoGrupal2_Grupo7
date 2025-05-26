using UnityEngine;

public class MeleeCharacterController : CharacterControllerBase
{
    [SerializeField] private GameObject attackZone;

    protected override void Attack()
    {
        base.Attack();

        if (attackZone != null)
        {
            attackZone.SetActive(true);
            Invoke(nameof(DisableAttackZone), 0.3f);
        }
    }

    private void DisableAttackZone()
    {
        if (attackZone != null)
            attackZone.SetActive(false);
    }
}
