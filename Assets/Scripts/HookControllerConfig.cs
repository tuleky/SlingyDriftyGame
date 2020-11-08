using ScriptableObjectArchitecture;
using UnityEngine;

[System.Serializable]
public class HookControllerConfig
{
    public Vector3GameEvent onHook;

    public GameEvent onContinuousHook;
    public GameEvent onRelease;
    public LayerMask searchLayer;
    [Range(0.2f, 2f)] public float turningSpeed;
    [Range(0.1f, 2f)] public float rotatingDuration;
    public float hookPointCheckRadius;
}