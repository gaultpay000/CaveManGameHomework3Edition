using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
    [NodeTint(0f, .5f, 0f)]
    public abstract class BTCompositeNodeBase : BTBaseNode
	{
        // both input and output
        [Input(connectionType = ConnectionType.Override)] public bool enter;
        [Output(dynamicPortList = true, connectionType = ConnectionType.Override)] public bool exit; //

        // # of outputs
        protected int _portCount;

        public override void InitNode(BTAgent owner)
        {
            base.InitNode(owner);
            _portCount = -1;

            //counts outputs
            foreach(NodePort port in Outputs)
            {
                _portCount++;
            }
        }
    }
}