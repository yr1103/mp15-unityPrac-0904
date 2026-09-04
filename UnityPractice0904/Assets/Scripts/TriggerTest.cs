using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    private SphereCollider b;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{gameObject.name}의 트리거 안에 {other.gameObject.name}가 들어옴 ");
        
        IDamageable d = other.gameObject.GetComponent<IDamageable>();
        
        if (d != null)
        {
            d.TakeDamage(10);
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"{gameObject.name}의 트리거 안에 {other.gameObject.name}가 있는 상태");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{gameObject.name}의 트리거 안에 있던 {other.gameObject.name}가 나감 ");
    }
    
    


}
