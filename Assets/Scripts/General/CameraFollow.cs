using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;

    private void Start()
    {
        target = GameManager.instance.PropCharacters.transform;
    }


    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(x,y,z), followSpeed * Time.deltaTime);
    }

}
