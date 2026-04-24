using System.Collections;
using UnityEngine;

namespace AICore
{
    [RequireComponent(typeof(SphereCollider))]
    public class AITrigger : MonoBehaviour
    {
        [SerializeField] private AIAgentBase _agent;
        [SerializeField] private SphereCollider _collider;
        [SerializeField]EnemyAnimationController controller;
        [SerializeField] Enemy enemy;

        IEnumerator instance;

        private void Awake()
        {
            _collider = GetComponent<SphereCollider>();
            _collider.isTrigger = true;

            if(transform.parent.GetComponentInChildren<AIAgentBase>() != null)
            {
                _agent = transform.parent.GetComponentInChildren<AIAgentBase>();
            }
            else
            {
                Debug.LogError("Trigger parent doesn't have an agent in its children");
            }
        }

        public void SetRadius(float r)
        {
            _collider.radius = r;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_agent == null || other.transform != _agent.transform)
            {
                return;
            }
            controller.SetIsWaiting = true;

            if(enemy.health <= 20 && instance != enemy.Heal())
            {
                instance = enemy.Heal();
                StartCoroutine(instance);
            }

            _agent.HasReachedDestination = true;
        }

        private void OnTriggerStay(Collider other)
        {
            if (_agent == null || other.transform != _agent.transform)
            {
                return;
            }
            controller.SetIsWaiting = true;

            _agent.HasReachedDestination = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (_agent == null || other.transform != _agent.transform)
            {
                return;
            } 
            if (instance == enemy.Heal())
            {
                StopCoroutine(instance);
                instance = null;    
            }

            controller.SetIsWaiting = false;

            _agent.HasReachedDestination = false;
        }
    }
}
