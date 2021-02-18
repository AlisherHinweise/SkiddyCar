using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;
    private bool _enableAnimationPlayer = false;

    [SerializeField] private CoinCollector _coinCollector;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _driftSpeed;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            _enableAnimationPlayer = true;
            if (_enableAnimationPlayer == true)
            {
                 _animator.SetInteger("AnimationCase", 1);
            }
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (_rb.velocity.z <= _maxSpeed)
            {
                _rb.AddForce(Mathf.SmoothStep(_rb.velocity.x, 0, _driftSpeed * Time.fixedDeltaTime), 0, _acceleration);
            }
        }
        else
        {
            if (_enableAnimationPlayer == true)
            {
                _animator.SetInteger("AnimationCase", 2);
             }
            transform.rotation = Quaternion.Euler(0, -90, 0);
            if (_rb.velocity.x >= -_maxSpeed)
                _rb.AddForce(-_acceleration, 0, Mathf.SmoothStep(_rb.velocity.z, 0, _driftSpeed * Time.fixedDeltaTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            Destroy(other.gameObject);
            _coinCollector.AddCoin();
        }
    }
}
