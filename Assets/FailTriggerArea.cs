using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class FailTriggerArea : MonoBehaviour
{
    [SerializeField] GameEvent onHittingFailArea;

    void OnTriggerEnter(Collider other)
    {
        onHittingFailArea.Raise();
    }
}
