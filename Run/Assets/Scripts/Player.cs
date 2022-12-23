using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BoxCollider boxCollider;
    public Rigidbody rb;
    public Animator _anim;
    public float speed = 5f;
    bool set = false;
    float _horizontal;
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            set = true;
            _anim.SetBool("Move", true);

        }
        if (set)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            _horizontal = Input.GetAxis("Horizontal");
            Vector3 movement = Vector3.right * _horizontal;
            transform.position += movement * speed * Time.deltaTime;
            Vector3 move = transform.position;
            move.x = Mathf.Clamp(move.x, -4.5f, 4.5f);
            transform.position = move;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            speed = 10f;
            Invoke("Power", 2f);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            boxCollider.isTrigger = true;
            Invoke("Casper", 2f);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("algýlandý");
        }
    }
    public void Power()
    {
        speed = 5f;
    }
    public void Casper()
    {
        rb.constraints = RigidbodyConstraints.None;
        boxCollider.isTrigger = false;
    }
}
