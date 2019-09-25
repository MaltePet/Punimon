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
}
