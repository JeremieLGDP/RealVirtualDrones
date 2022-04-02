using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/All Physics Layer")]
public class AllPhysicsFilter : ContextFilter
{
    public LayerMask mask;
    public LayerMask mask1;
    public LayerMask mask2;

    public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform item in original)
        {
            if (mask == (mask | (1 << item.gameObject.layer)) || mask1 == (mask1 | (1 << item.gameObject.layer)) || mask2 == (mask2 | (1 << item.gameObject.layer)))
            {
                filtered.Add(item);
            }
        }
        return filtered;
    }
}