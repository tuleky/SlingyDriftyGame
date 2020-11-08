using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class ScriptableEnumEvent : UnityEvent<ScriptableEnum> { }

	[CreateAssetMenu(
	    fileName = "ScriptableEnumVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "ScriptableEnum",
	    order = 120)]
	public class ScriptableEnumVariable : BaseVariable<ScriptableEnum, ScriptableEnumEvent>
	{
	}
}