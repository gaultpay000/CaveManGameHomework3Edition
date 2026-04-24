using UnityEngine;
using AICore;
using System.Collections.Generic;

namespace BehaviorTree
{
    public class BTAgent : AIAgentBase
    {
        [SerializeField] private BehaviorTreeGraph btGraph;
        [SerializeField] private Transform[] _waypoints;
        [SerializeField] Transform[] hidingSpots;
        Enemy enemy;

        Dictionary<string, object> _blackboard;

        Rigidbody rb;
        
        public Dictionary<string, object> GetBlackboard { get {  return _blackboard; } }

        protected override void Start()
        {
            enemy = GetComponentInChildren<Enemy>();
            base.Start();
            rb = GetComponent<Rigidbody>();

            _blackboard = new Dictionary<string, object>();
            _blackboard.Add("Waypoints", _waypoints);
            _blackboard.Add("WaypointIndex", 0);

            if (btGraph != null)
            {
                btGraph = btGraph.Copy() as BehaviorTreeGraph; 
                btGraph.InitBehaviorTree(this);
            }
        }

        protected override void FixedUpdate()
        {

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            if (enemy.health <= 20)
            {
                Transform closestHidingSpot = FindHidingSpot();
                SetTarget(closestHidingSpot.position, null, 
                Vector3.Distance(transform.position, closestHidingSpot.position), 
                Time.time, TargetType.Waypoint);
                GetNavMeshAgent.SetDestination(closestHidingSpot.position);
            }
            else
            {
            AssessTargets();

            if(btGraph != null && btGraph.RootNode != null)
            {
                btGraph.Update();
            }

            base.FixedUpdate(); //clear target stuff
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<PlayerMovement>() != null) 
            {
                StartCoroutine(FindAnyObjectByType<EnemyAnimationController>().Kick());
                collision.gameObject.GetComponent<PlayerMovement>().playerHealth -= 20;
            }
            
        }

        Transform FindHidingSpot()
        {
            Transform bestSpot = null;
            float bestDistance = Mathf.Infinity;
            for (int i = 0; i < hidingSpots.Length; i++)
            {
                float curDistance = Vector3.Distance(transform.position, hidingSpots[i].position);

                if(curDistance < bestDistance)
                {
                    bestDistance = curDistance;
                    bestSpot = hidingSpots[i];
                }
            }
            return bestSpot;
        }
    }
}
