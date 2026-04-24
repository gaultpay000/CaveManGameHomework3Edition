using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;
using AICore;
using XNode;
using static UnityEngine.UI.GridLayoutGroup;

public class AttackAction : BTActionNodeBase
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (_owner.GetCurrTarget.GetTargetType == TargetType.Visual)
        {
            Vector3 dir = _owner.transform.position - _owner.GetSensorPosition;
            float angle = Vector3.Angle(_owner.transform.forward, dir);

            RaycastHit hit;
            if (Physics.Raycast(_owner.GetSensorPosition, dir.normalized, out hit,
                _owner._sightRange * _owner.GetSensorRadius))
            {
                if (hit.collider.gameObject.GetComponent<PlayerMovement>() != null)
                {
                    hit.collider.gameObject.GetComponent<PlayerMovement>().playerHealth -= 20;
                }
            }
        }
        return State.Success;
    }
}
