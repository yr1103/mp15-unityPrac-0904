using UnityEngine;

namespace DefaultNamespace
{
    public interface IMoveable
    {
        public void Move();
        public bool IsMoving { get; set; }
        
        public void SetDestination(Vector3 destination);
    }
}