using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
    public class SequencerNode : BTCompositeNodeBase
    {
        protected override void OnStart()
        {
        }

        protected override void OnStop()
        {
        }
        //cycles through output nodes on a return of success, if node fails, stops sequencing, will stop running outputs on return of failure
        protected override State OnUpdate()
        {
            int curIndex = 0;

            foreach (NodePort port in Outputs)
            {
                if (port.Connection == null || port.Connection.node == null
                    || port.Connection.node is BTBaseNode == false)
                {
                    continue;
                }

                BTBaseNode child = port.Connection.node as BTBaseNode;

                switch (child.Update())
                {
                    case State.Running:
                        return State.Running;
                    case State.Failure:
                        return State.Failure;
                    case State.Success:
                        curIndex++;
                        continue;
                }
            }

            return curIndex == _portCount ? State.Success : State.Running;
        }
    }
}