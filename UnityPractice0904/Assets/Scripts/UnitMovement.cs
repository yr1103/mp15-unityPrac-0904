using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class UnitMovement : MonoBehaviour, IMoveable, ISelectable
{
    // 1. 목적지를 받기
    // 2. 목적지가 정해져있으면 그쪽으로 이동하기
    // 3. 목적지에 도착하면 목적지 해제하기

    public Vector3 Destination{ get; set;}
    public bool IsMoving { get; set; }
    [SerializeField] private float _moveSpeed;

    public UnitMovement(Vector3 _destination, float moveSpeed)
    {
        Destination = _destination;
        _moveSpeed = moveSpeed;
    }
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (!IsMoving) return;
        
        transform.position = Vector3.MoveTowards(
            transform.position, 
            Destination, 
            Time.deltaTime   * _moveSpeed);

        if (Vector3.Distance(transform.position, Destination) <= 0.1f)
        {
            IsMoving = false;
        }
    }
    
    public void SetDestination(Vector3 destination)
    {
        Destination = destination;
        IsMoving = true;
    }
}
