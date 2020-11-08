using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class StraightMoverConfigReference : BaseReference<StraightMoverConfig, StraightMoverConfigVariable>
	{
	    public StraightMoverConfigReference() : base() { }
	    public StraightMoverConfigReference(StraightMoverConfig value) : base(value) { }
	}
}