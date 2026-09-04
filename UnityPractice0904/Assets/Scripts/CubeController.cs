using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor.Search;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private ISelectable _target;
    
    private void Start()
    {
        _cam = Camera.main;
        
    }
    
    private void Update()
    {
        RayShot();
        MoveTarget();
    }

    public void MoveTarget()
    {
        if (!Input.GetMouseButton(1) || 
            _target == null ||
            !(_target is IMoveable)) 
            return;

        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (!hit.transform.CompareTag("Ground")) return;
            //Ray가 부딪힌 시점 기준
            (_target as IMoveable).SetDestination(hit.point);
        }
    }

    private void RayShot()
    {   
        if (!Input.GetMouseButton(0)) return;
        
        // 카메라 기준으로 클릭 처리하게
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {   // 땅 찍으면 null 하고 리턴
            _target = hit.transform.GetComponent<ISelectable>();
           
            if (hit.transform.CompareTag("Ground"))
            {
                _target = null;
                return;
            }
            Debug.Log($"{hit.transform.name} 선택"); 
        }
        else // 아무것도 없는데 찍으면 null
        {
            _target = null;
            return;
        }
    }
}