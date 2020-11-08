using ScriptableObjectArchitecture;
using UnityEngine;

public class HookPoint : MonoBehaviour
{
    [SerializeField] LevelChunkDataVariable chunkData;

    public int GetRotatingDirection()
    {
        return chunkData.Value.turningDirection;
    }
}
