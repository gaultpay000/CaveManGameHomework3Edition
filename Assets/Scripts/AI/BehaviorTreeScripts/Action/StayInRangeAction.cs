using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;
using XNode;
using static UnityEngine.UI.GridLayoutGroup;

public class StayInRangeAction : BTActionNodeBase
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
                if (Vector3.Distance(_owner.transform.position, _owner.GetCurrTarget.GetPosition) > 10)
                {
                    _owner.GetNavMeshAgent.SetDestination(_owner.GetCurrTarget.GetPosition);
                }
                else
                {
                    Vector3 awayFromPlayer = _owner.transform.position - _owner.GetCurrTarget.GetPosition;
                    Vector3 newTarget = _owner.GetCurrTarget.GetPosition + awayFromPlayer.normalized * 10;
                    _owner.GetNavMeshAgent.SetDestination(newTarget);
                    
                }
                //else if (Vector3.Distance(_owner.transform.position, _owner.GetCurrTarget.GetPosition) < 5)
                //{
                //    _owner.GetNavMeshAgent.SetDestination(_owner.GetCurrTarget.GetPosition);
                //    _owner.transform.Translate(Vector3.back * Time.deltaTime * 7);
                //}
            }
            else
                return State.Running;

            return State.Success;
        }
    }