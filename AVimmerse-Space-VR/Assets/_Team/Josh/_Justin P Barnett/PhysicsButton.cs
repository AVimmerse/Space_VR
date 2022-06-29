using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Button functionality - allows for onPressed and onReleased UnityEvents to be called
/// </summary>
public class PhysicsButton : MonoBehaviour
{

    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent onPressed;
    public UnityEvent onReleased;

    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1) // Test for a press
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
    }
}

// Source: https://www.youtube.com/watch?v=HFNzVMi5MSQ&ab_channel=JustinPBarnett