using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class LevelChunkDataEvent : UnityEvent<LevelChunkData> { }

	[CreateAssetMenu(
	    fileName = "LevelChunkDataVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "LevelChunkData",
	    order = 120)]
	public class LevelChunkDataVariable : BaseVariable<LevelChunkData, LevelChunkDataEvent>
	{
	}
}