using UnityEngine;

[System.Serializable]
public class LevelChunkData
{
    public enum Direction
    {
        North, East, South, West
    }

    public GameObject[] levelChunks;
    public Vector2 chunkSize = new Vector2(10f, 10f);

    public int turningDirection;       // 0 for straight, -1 for left, 1 for right

    public Direction entryDirection;
    public Direction exitDirection;


    public static Direction GetOppositeDirection(Direction dir)
    {
        switch (dir)
        {
            case Direction.North:
                return Direction.South;
            case Direction.East:
                return Direction.West;
            case Direction.South:
                return Direction.North;
            case Direction.West:
                return Direction.East;
            default:
                return Direction.North;
        }
    }
}