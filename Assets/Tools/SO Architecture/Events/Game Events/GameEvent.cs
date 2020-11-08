using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "GameEvent.asset",
        menuName = SOArchitecture_Utility.GAME_EVENT + "Game Event",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_EVENTS - 1)]
    [System.Serializable]
    public sealed class GameEvent : GameEventBase
    {
    } 
}