using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    IInputReceivable[] inputReceivable;

    void Awake()
    {
        inputReceivable = GetComponentsInChildren<IInputReceivable>();
        if (inputReceivable == null)
        {
            Debug.LogError("Input Receivable interface couldn't find");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var item in inputReceivable)
            {
                item.TouchDownReceived();
            }
        }

        if (Input.GetMouseButton(0))
        {
            foreach (var item in inputReceivable)
            {
                item.TouchReceived();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            foreach (var item in inputReceivable)
            {
                item.TouchUpReceived();
            }
        }
    }
}