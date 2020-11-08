using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class HookControllerConfigReference : BaseReference<HookControllerConfig, HookControllerConfigVariable>
	{
	    public HookControllerConfigReference() : base() { }
	    public HookControllerConfigReference(HookControllerConfig value) : base(value) { }
	}
}