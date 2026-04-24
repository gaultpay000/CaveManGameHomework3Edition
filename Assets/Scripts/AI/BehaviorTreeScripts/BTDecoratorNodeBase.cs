using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
    [NodeTint(.5f, 0f, 0f)]
    public abstract class BTDecoratorNodeBase : BTBaseNode
    {
        //input and output
        [Input(connectionType = ConnectionType.Override)] public bool enter;
        [Output(connectionType = ConnectionType.Override)] public bool exit;
    }
}