using DG.Tweening;
using ScriptableObjectArchitecture;
using UnityEngine;

public class StraightMover : MonoBehaviour, IPausableSystem
{
    [SerializeField] StraightMoverConfigReference straightMoverConfig;

    [SerializeField] Ease animEase;
    Sequence sequence;

    Vector3 directionToGo;

    bool canGo;

    float turningDegree;

    void Awake()
    {
        //sequence = DOTween.Sequence();
        //sequence.Append(transform.DOLookAt(transform.position + directionToGo * 5f, 0.5f));
        //sequence.Append(transform.DOPunchRotation(Vector3.up * 15, 1f, 0, 0.7f));
    }

    void Update()
    {
        if (canGo)
        {
            // die when you leave the road
            // Change here for more physically accurate rotating
           

            // forward movement
            transform.Translate(transform.forward * straightMoverConfig.Value.speed * Time.deltaTime, Space.World);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        DirectionInfo directionInfo = other.GetComponent<DirectionInfo>();

        if (directionInfo != null)
        {
            directionToGo = directionInfo.direction;
        }
    }

    public void FixRotation()
    {
        if (directionToGo != Vector3.zero)
        {
            transform.DOLookAt(transform.position + directionToGo * 3f, 3f).SetEase(animEase);
        }
    }

    public void EnableCanGo()
    {
        canGo = true;
    }

    public void DisableCanGo()
    {
        canGo = false;
    }

    public void Pause()
    {
        DisableCanGo();
    }

    public void Resume()
    {
        EnableCanGo();
    }
}