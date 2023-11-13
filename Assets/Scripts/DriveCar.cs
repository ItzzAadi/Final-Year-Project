using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Integrations.Match3;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frontTireRB;
    [SerializeField] private Rigidbody2D _backTireRB;
    [SerializeField] private Rigidbody2D _carRBCheckingIfThisWillSHow;
    [SerializeField] private float _speed = 150f; //7
    [SerializeField] private float _rotationSpeed = 300f; //40
    private float __moveInput;
    
    private void Update(){
        __moveInput = Input.GetAxisRaw("Horizontal");
        Move(__moveInput);
    }

    private void Move(float _moveInput){
        _frontTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _backTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _carRBCheckingIfThisWillSHow.AddTorque(_moveInput * _rotationSpeed * Time.fixedDeltaTime);
    }
}
