using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quokka : MonoBehaviour
{

    public float speed = 2.5f;

    // References
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    // Movement
    private Vector2 _movement;

    void Awake () {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _movement = new Vector2(horizontalInput, 0f);
    }

    void FixedUpdate(){
        float horizontalVelocity = _movement.normalized.x * speed;
        _rigidbody.velocity = new Vector2(horizontalVelocity,_rigidbody.velocity.y);
    }

    void LateUpdate(){
        _animator.SetBool("Idle", _movement == Vector2.zero);
    }
}
