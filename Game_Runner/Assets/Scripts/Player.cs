using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    float _vertical, _horizontal, speed = 5f;
    [SerializeField] private Animator _animator;
    private void FixedUpdate()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (_horizontal<0&&transform.position.x>-4)
        {
            transform.position = Vector3.Lerp(transform.position,new Vector3( transform.position.x - 2f, transform.position.y, transform.position.z),1f*Time.deltaTime);
        }
        else if (_horizontal>0&&transform.position.x<4)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
    }
}
