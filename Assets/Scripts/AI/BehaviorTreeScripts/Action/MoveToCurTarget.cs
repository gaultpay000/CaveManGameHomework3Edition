using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
    public class MoveToCurTarget : BTActionNodeBase
    {
        protected override void OnStart()
        {
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (_owner.GetNavMeshAgent.pathPending == false)
            {
                _owner.GetNavMeshAgent.SetDestination(_owner.GetCurrTarget.GetPosition);
            }
            else
                return State.Running;

            return State.Success;
        }
    }
}