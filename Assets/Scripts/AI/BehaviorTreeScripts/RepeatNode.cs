using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
    public class RepeatNode : BTDecoratorNodeBase
    {
        protected override void OnStart()
        {
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            BTBaseNode child = GetPort("exit").Connection.node as BTBaseNode;
            child.Update();

            return State.Running;
        }
    }
}