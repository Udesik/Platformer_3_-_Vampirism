using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const KeyCode JumpKey = KeyCode.Space;

    public float Direction { get; private set; }
    public event Action JumpRequested;

    private void Update()
    {
        Direction = Input.GetAxisRaw(HorizontalAxis);
        
        if (Input.GetKeyDown(JumpKey))
            JumpRequested?.Invoke();
    }
}