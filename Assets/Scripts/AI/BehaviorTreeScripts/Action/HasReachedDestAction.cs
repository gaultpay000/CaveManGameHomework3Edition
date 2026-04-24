using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;


namespace BehaviorTree 
{ 
	public class HasReachedDestAction : BTActionNodeBase 
	{
        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            return _owner.HasReachedDestination ? State.Success : State.Failure;
        }

        protected override void OnStop()
        {
        }
    }
}