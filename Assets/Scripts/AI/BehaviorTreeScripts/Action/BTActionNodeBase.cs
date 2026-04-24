using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
	[NodeTint(0f, 0f, .5f)]
	public abstract class BTActionNodeBase : BTBaseNode
	{
		//only has inputs
		[Input(connectionType = ConnectionType.Override)] public bool enter;
	}
}