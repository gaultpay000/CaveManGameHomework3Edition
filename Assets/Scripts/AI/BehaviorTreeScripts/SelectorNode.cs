using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
    public class SelectorNode : BTCompositeNodeBase
    {
        protected override void OnStart()
        {
        }

        protected override void OnStop()
        {
        }
        //cycles through output nodes on a return of failure, if node fails, next output is run will run all outputs
        protected override State OnUpdate()
        {
            int curIndex = 0;

            foreach(NodePort port in Outputs)
            {
                if(port.Connection == null || port.Connection.node == null 
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
                        curIndex++;
                        continue;
                    case State.Success:
                        return State.Success;
                }
            }

            return curIndex == _portCount ? State.Failure : State.Running;
        }
    }
}