using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovements : MonoBehaviour
{
    #region Fields

    protected NavMeshAgent _agent;
    protected Attribute _movementSpeed;

    #endregion Fields
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _movementSpeed = new Attribute(3.5f);
        _movementSpeed.OnValueChanged += UpdateMovementSpeed;
    }

    #region Methods

    private void UpdateMovementSpeed(float newMovementSpeed)
    {
        _agent.speed = _movementSpeed.Value;
    }

    #endregion Methods
}