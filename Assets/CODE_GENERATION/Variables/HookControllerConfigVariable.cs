using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class HookControllerConfigEvent : UnityEvent<HookControllerConfig> { }

	[CreateAssetMenu(
	    fileName = "HookControllerConfigVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "HookControllerConfig",
	    order = 120)]
	public class HookControllerConfigVariable : BaseVariable<HookControllerConfig, HookControllerConfigEvent>
	{
	}
}