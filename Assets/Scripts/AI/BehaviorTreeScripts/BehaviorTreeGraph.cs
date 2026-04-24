using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
	[CreateAssetMenu]
	public class BehaviorTreeGraph : NodeGraph
	{
		private BTBaseNode _rootNode;
		private State _curState;

		public BTBaseNode RootNode 
		{
			get 
			{
				if (_rootNode == null)
					FindRootNode();

				return _rootNode; 
			}
			set
			{
				_rootNode = value;
			}
		}

		public void FindRootNode()
		{
			foreach(Node node in nodes)
			{
				if(node is RootNode)
				{
					_rootNode = node as RootNode;
					return;
				}
			}
		}

		public void InitBehaviorTree(BTAgent owner)
		{
			FindRootNode();
			InitNodes(owner);
		}

		public void InitNodes(BTAgent owner)
		{
			foreach (BTBaseNode node in nodes)
			{
				node.InitNode(owner);
				node.hasStarted = false;
			}
		}

		public State Update()
		{
			if (_rootNode == null)
				_curState = State.Failure;
			else if (_rootNode.state == State.Running || _rootNode.state == State.Success)
				_curState = _rootNode.Update();

			return _curState;
		}
	}
}