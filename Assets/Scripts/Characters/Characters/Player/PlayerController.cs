using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Fields

    private PlayerInput _inputs;
    private PlayerMovements _playerMovements;

    #endregion Fields

    #region Actions

    public void OnMove(InputAction.CallbackContext context)
    {
        _playerMovements.move = context.performed;
    }

    #endregion Actions

    #region Methods

    private void Awake()
    {
        _inputs = GetComponent<PlayerInput>();
        _playerMovements = GetComponent<PlayerMovements>();
    }

    #endregion Methods
}