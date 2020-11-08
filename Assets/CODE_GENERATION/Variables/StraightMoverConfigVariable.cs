using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class StraightMoverConfigEvent : UnityEvent<StraightMoverConfig> { }

	[CreateAssetMenu(
	    fileName = "StraightMoverInfoVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "StraightMoverInfo",
	    order = 120)]
	public class StraightMoverConfigVariable : BaseVariable<StraightMoverConfig, StraightMoverConfigEvent>
	{
	}
}