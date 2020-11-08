using DG.Tweening;
using ScriptableObjectArchitecture;
using UnityEngine;

public class HookController : MonoBehaviour, IInputReceivable, IPausableSystem
{
    [SerializeField] HookControllerConfigReference hKConfig;

    HookPoint closestPoint;
    Vector2 objectPosition2D;
    Vector2 originPosition2D;

    float circleRadius;
    float currentPercentage;

    int turningDirection;

    bool canHook;
    bool couldFindHookPoint;


    public void TouchDownReceived()
    {
        if (canHook)
        {
            closestPoint = FindClosestPoint();
            if (closestPoint == null)
            {
                couldFindHookPoint = false;
            }
            else
            {
                couldFindHookPoint = true;
                hKConfig.Value.onHook.Raise(closestPoint.transform.position);
            }
        }
    }

    public void TouchReceived()
    {
        if (!couldFindHookPoint)
            return;

        turningDirection = closestPoint.GetRotatingDirection();

        objectPosition2D = new Vector2(transform.position.x, transform.position.z);
        originPosition2D = new Vector2(closestPoint.transform.position.x, closestPoint.transform.position.z);


        currentPercentage = MathHelper.FindPercentageInArch(originPosition2D, objectPosition2D, out circleRadius);
        Vector2 nextPointInCircle = MathHelper.GiveNextPointInArchByPercentage(turningDirection, currentPercentage, circleRadius,
            hKConfig.Value.turningSpeed * Time.deltaTime, originPosition2D);
        Vector3 moveVector = new Vector3(nextPointInCircle.x, transform.position.y, nextPointInCircle.y);
        transform.position = moveVector;

        Vector3 lookingTarget = new Vector3(closestPoint.transform.position.x, transform.position.y, closestPoint.transform.position.z);
        transform.DOLookAt(lookingTarget, hKConfig.Value.rotatingDuration);


        hKConfig.Value.onContinuousHook.Raise();
    }

    public void TouchUpReceived()
    {
        // when we release our hook
        if (couldFindHookPoint)
        {
            hKConfig.Value.onRelease.Raise();
            couldFindHookPoint = false;
            //transform.DOKill();
        }
    }

    HookPoint FindClosestPoint()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, hKConfig.Value.hookPointCheckRadius, hKConfig.Value.searchLayer, QueryTriggerInteraction.Collide);
        if (colls.Length == 0)
        {
            return null;
        }

        Vector3 closestPoint = colls[0].transform.position - transform.position;
        Collider result = colls[0];

        for (int i = 1; i < colls.Length; i++)
        {
            if (closestPoint.sqrMagnitude > (colls[i].transform.position - transform.position).sqrMagnitude)
            {
                closestPoint = colls[i].transform.position - transform.position;
                result = colls[i];
            }
        }

        return result.GetComponent<HookPoint>();
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, hKConfig.Value.hookPointCheckRadius);
    }

    public void EnableCanHook()
    {
        canHook = true;
    }

    public void DisableCanHook()
    {
        canHook = false;
    }

    public void Pause()
    {
        DisableCanHook();
    }

    public void Resume()
    {
        
    }
}