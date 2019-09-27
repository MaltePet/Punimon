using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    private Rigidbody2D _rigidbody;
    private Vector2 _movement;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (!_rigidbody) _rigidbody = gameObject.AddComponent<Rigidbody2D>();

        _animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed", _movement.magnitude);
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + Time.fixedDeltaTime * _moveSpeed * _movement);
    }
    
    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Door"))
        {
            // It's a door!
            DoorBehaviour doorBehaviour = col.gameObject.GetComponent<DoorBehaviour>();
            doorBehaviour.OpenScene();
        }
        else
        {
            Debug.Log("Else: " + col.gameObject.tag); 
            Debug.Log(col.gameObject.name);
        }
    }
    
    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
    }
}
