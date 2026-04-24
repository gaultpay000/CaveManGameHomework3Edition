using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using AICore;

namespace BehaviorTree
{
    public class SetNextWaypointAction : BTActionNodeBase
    {
        public string waypointName;

        public string waypointIndex;

        public WaypointType waypointType;

        Transform[] waypoints;

        public enum WaypointType
        {
            Linear,
            Random
        }

        protected override void OnStart()
        {
            if (waypoints == null || !_owner.GetBlackboard.ContainsKey(waypointIndex))
                return;

            switch (waypointType)
            {
                case WaypointType.Linear:
                    int v = (int)_owner.GetBlackboard[waypointIndex];
                    v++;

                    if (v > waypoints.Length - 1)
                        v = 0;

                    _owner.GetBlackboard[waypointIndex] = v;
                    break;

                case WaypointType.Random:
                    _owner.GetBlackboard[waypointIndex] = Random.Range(0, waypoints.Length);
                    break;
            }
            
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if(!_owner.GetBlackboard.ContainsKey(waypointName) 
                || !_owner.GetBlackboard.ContainsKey(waypointIndex))
                return State.Failure;
            
            Transform newPoint = waypoints[(int)_owner.GetBlackboard[waypointIndex]];

            _owner.SetTarget(newPoint.position, null, 
                Vector3.Distance(_owner.transform.position, newPoint.position), 
                Time.time, TargetType.Waypoint);

            return State.Success;
        }

        public override void InitNode(BTAgent owner)
        {
            base.InitNode(owner);

            if (_owner.GetBlackboard.ContainsKey(waypointName))
            {
                waypoints = _owner.GetBlackboard[waypointName] as Transform[];
            }
        }
    }
}