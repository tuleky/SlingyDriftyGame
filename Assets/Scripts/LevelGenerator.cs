using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] LevelChunkDataVariable[] levelChunkDatas;
    [SerializeField] LevelChunkDataVariable firstChunk;

    LevelChunkDataVariable previousChunk;

    [SerializeField] Vector3 spawnOrigin;

    Vector3 spawnPosition;
    [SerializeField] int firstChunksToSpawn = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PickAndSpawnChunk();
        }
    }

    [ContextMenu("SpawnChunk")]
    void Start()
    {
        previousChunk = firstChunk;

        for (int i = 0; i < firstChunksToSpawn; i++)
        {
            PickAndSpawnChunk();
        }
    }

    public void PickAndSpawnChunk()
    {
        LevelChunkDataVariable chunkToSpawn = PickNextChunk();

        GameObject objectFromChunk = chunkToSpawn.Value.levelChunks[Random.Range(0, chunkToSpawn.Value.levelChunks.Length)];
        previousChunk = chunkToSpawn;
        Instantiate(objectFromChunk, spawnPosition + spawnOrigin, Quaternion.identity);
    }

    LevelChunkDataVariable PickNextChunk()
    {
        List<LevelChunkDataVariable> allowedChunkList = new List<LevelChunkDataVariable>();
        LevelChunkDataVariable nextChunk = null;

        // Pick Next Chunk by looking at the previous chunks allowed directions
        LevelChunkData.Direction nextRequiredEntryDirection = LevelChunkData.Direction.North;


        // if previous chunk is a U road, we want to adjust spawn position
        if (previousChunk.Value.entryDirection == previousChunk.Value.exitDirection)
        {
            spawnPosition += new Vector3(0f, 0f, previousChunk.Value.chunkSize.y / 2f);
        }


        switch (previousChunk.Value.exitDirection)
        {
            case LevelChunkData.Direction.North:
                nextRequiredEntryDirection = LevelChunkData.Direction.South;
                spawnPosition += new Vector3(0f, 0f, previousChunk.Value.chunkSize.y);
                break;

            case LevelChunkData.Direction.East:
                nextRequiredEntryDirection = LevelChunkData.Direction.West;
                spawnPosition += new Vector3(previousChunk.Value.chunkSize.x, 0f, 0f);
                break;

            case LevelChunkData.Direction.South:
                nextRequiredEntryDirection = LevelChunkData.Direction.North;
                spawnPosition += new Vector3(0f, 0f, -previousChunk.Value.chunkSize.y);
                break;

            case LevelChunkData.Direction.West:
                nextRequiredEntryDirection = LevelChunkData.Direction.East;
                spawnPosition += new Vector3(-previousChunk.Value.chunkSize.x, 0f, 0f);
                break;

            default:
                break;
        }

        // if previous chunk is a corner chunk then we want straight road next time
        LevelChunkData.Direction nextRequiredExitDirection;
        if (previousChunk.Value.turningDirection != 0)
        {
            nextRequiredExitDirection = LevelChunkData.GetOppositeDirection(nextRequiredEntryDirection);

            foreach (var item in levelChunkDatas)
            {
                if (item.Value.entryDirection == nextRequiredEntryDirection && item.Value.exitDirection == nextRequiredExitDirection)
                {
                    allowedChunkList.Add(item);
                }
            }
        }
        else
        {
            foreach (var item in levelChunkDatas)
            {
                if (item.Value.entryDirection == nextRequiredEntryDirection)
                {
                    allowedChunkList.Add(item);
                }
            }
        }


        nextChunk = allowedChunkList[Random.Range(0, allowedChunkList.Count)];

        return nextChunk;
    }
}