using UnityEngine;

namespace AICore
{
    [RequireComponent(typeof(SphereCollider))]
    public class AISensor : MonoBehaviour
    {
        [SerializeField] private AIAgentBase _agent;
        [SerializeField] private SphereCollider _collider;

        public SphereCollider GetSphereCollider
        {
            get
            {
                if(_collider == null)
                    _collider = GetComponent<SphereCollider>();

                return _collider;
            }
        }

        private void Awake()
        {
            GetSphereCollider.isTrigger = true;

            if (GetComponentInParent<AIAgentBase>() != null)
            {
                _agent = GetComponentInParent<AIAgentBase>();
            }
            else
            {
                Debug.LogError("AI sensor requires a parent with AIAgent");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_agent == null) { return; }

            _agent.OnSensorEvent(TriggerEventType.Enter, other);
        }

        private void OnTriggerStay(Collider other)
        {
            if (_agent == null) { return; }

            _agent.OnSensorEvent(TriggerEventType.Stay, other);
        }

        private void OnTriggerExit(Collider other)
        {
            if (_agent == null) { return; }

            _agent.OnSensorEvent(TriggerEventType.Exit, other);
        }
    }
    public enum TriggerEventType
    {
        Enter,
        Stay,
        Exit
    }
}