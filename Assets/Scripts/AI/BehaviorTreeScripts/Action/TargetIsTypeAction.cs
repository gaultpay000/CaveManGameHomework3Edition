using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using AICore;

namespace BehaviorTree
{
    public class TargetIsTypeAction : BTActionNodeBase
    {
        public TargetType targetType;

        protected override void OnStart()
        {
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            return _owner.GetCurrTarget.GetTargetType == targetType ? 
                State.Success : State.Failure;
        }
    }
}