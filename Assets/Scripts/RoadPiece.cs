using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class RoadPiece : MonoBehaviour
{
    public LevelChunkDataVariable chunkData;
    [SerializeField] GameEvent onHookObjectEntersHookableRoad;
    [SerializeField] GameEvent onHookObjectExitsHookableRoad;

    [SerializeField] GameEvent onHookObjectExitsAnyRoad;

    void OnTriggerEnter(Collider other)
    {
        if (chunkData.Value.turningDirection == 0)
            return;

        HookController hc = other.GetComponent<HookController>();

        if (hc != null)
        {
            onHookObjectEntersHookableRoad.Raise();
        }
    }

    void OnTriggerExit(Collider other)
    {
        HookController hc = other.GetComponent<HookController>();

        if (hc == null)
            return;

        onHookObjectExitsAnyRoad.Raise();

        if (chunkData.Value.turningDirection != 0)
        {
            onHookObjectExitsHookableRoad.Raise();
        }
    }
}