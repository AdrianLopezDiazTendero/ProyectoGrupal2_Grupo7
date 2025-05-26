using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject meleeCharacter;
    public GameObject rangedCharacter;

    private ICharacterController activeCharacter;
    private GameObject activeGO;

    void Start()
    {
        meleeCharacter.SetActive(true);
        rangedCharacter.SetActive(false);

        SwitchToCharacter(meleeCharacter);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameObject next = activeGO == meleeCharacter ? rangedCharacter : meleeCharacter;
            SwitchToCharacter(next);
        }

        activeCharacter?.HandleInput();
    }

    void SwitchToCharacter(GameObject newCharacter)
    {
        // 1. Guardar posición del personaje actual
        Vector3 previousPosition = activeGO != null ? activeGO.transform.position : Vector3.zero;

        // 2. Desactivar el personaje actual
        if (activeGO != null)
            activeGO.SetActive(false);

        // 3. Posicionar el nuevo personaje en la misma posición
        newCharacter.transform.position = previousPosition;

        // 4. Activar el nuevo personaje
        activeGO = newCharacter;
        activeGO.SetActive(true);

        // 5. Obtener el controlador del personaje
        activeCharacter = activeGO.GetComponent<ICharacterController>();
    }
}
