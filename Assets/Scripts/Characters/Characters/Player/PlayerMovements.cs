using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : CharacterMovements
{
    #region Fields

    [SerializeField] private Camera _playerCamera;
    [SerializeField] private LayerMask _whatCanBeClickedOn;
    public bool move;

    #endregion Fields

    #region Methods

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!move) return;

        var ray = _playerCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out var hitInfos, 100, _whatCanBeClickedOn)) _agent.SetDestination(hitInfos.point);
    }

    #endregion Methods
}