using UnityEngine;

public class Pauser : MonoBehaviour
{
    IPausableSystem[] pausableSystems;

    void Awake()
    {
        pausableSystems = GetComponents<IPausableSystem>();
    }


    public void PauseSystems()
    {
        foreach (IPausableSystem item in pausableSystems)
        {
            item.Pause();
        }
    }

    public void ResumeSystems()
    {
        foreach (IPausableSystem item in pausableSystems)
        {
            item.Resume();
        }
    }
}
