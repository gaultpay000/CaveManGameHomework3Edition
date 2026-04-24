using UnityEngine;
using UnityEngine.AI;

namespace AICore
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))] //
    public class AIAgentBase : MonoBehaviour
    {
        [SerializeField, Range(0f, 360f)] protected float _fov = 60f;
        [SerializeField, Range(0f, 1f)] public float _sightRange = 1f; //0-100% sphere col.

        [SerializeField] protected AISensor _sensor;

        [SerializeField] protected Target _curTarget = new Target();
        [SerializeField] protected Target _visualTarget = new Target();

        protected NavMeshAgent _navAgent;
        protected bool _hasReachedDestination = false;

        [SerializeField] private AITrigger _trigger;

        public bool HasReachedDestination {  get { return _hasReachedDestination; }
            set { _hasReachedDestination = value; } }
        public Target GetCurrTarget { get { return _curTarget; } }
        public AITrigger GetTrigger { get { return _trigger; } }
        public NavMeshAgent GetNavMeshAgent { get { return _navAgent; } }

        public Vector3 GetSensorPosition
        {
            get
            {
                if (_sensor == null) return Vector3.zero;

                Vector3 pos = _sensor.transform.position;
                pos.x += _sensor.GetSphereCollider.center.x * _sensor.transform.lossyScale.x;
                pos.y += _sensor.GetSphereCollider.center.y * _sensor.transform.lossyScale.y;
                pos.z += _sensor.GetSphereCollider.center.z * _sensor.transform.lossyScale.z;
                return pos;
            }
        }

        public float GetSensorRadius
        {
            get
            {
                if (_sensor == null) return 0f;

                float sensorRad = _sensor.GetSphereCollider.radius;

                float radius = Mathf.Max(sensorRad * _sensor.transform.lossyScale.x,
                    sensorRad * _sensor.transform.lossyScale.y);

                return Mathf.Max(radius, sensorRad * _sensor.transform.lossyScale.z);
            }
        }

        enum EnemyStates
        {
            Wander,
            Search,
            Attack
        }
        EnemyStates curState;

        protected virtual void Start()
        {
            _navAgent = GetComponent<NavMeshAgent>();
        }

        public void OnSensorEvent(TriggerEventType tet, Collider other)
        {
            if (other == null || tet == TriggerEventType.Exit)
            {
                return;
            }

            if (other.CompareTag("Player")) // fix
            {
                if (IsColliderVisible(other))
                {
                    _visualTarget.Set(other.transform.position, other,
                        Vector3.Distance(transform.position, other.transform.position),
                        Time.time, TargetType.Visual);
                    curState = EnemyStates.Attack;
                }
            }
            else curState = EnemyStates.Wander;
        }

        public void AssessTargets()
        {
            if (_visualTarget != null && _visualTarget.GetTargetType == TargetType.Visual)
            {
                SetTarget(_visualTarget.GetPosition, _visualTarget.GetCollider,
                    _visualTarget.Distance, _visualTarget.GetTime, _visualTarget.GetTargetType);
            }
            else if (_curTarget.GetTargetType != TargetType.Waypoint) 
            { 
                _curTarget.Clear();
            }
        }

        protected virtual void FixedUpdate()
        {
            ClearTargets();
        }

        protected void ClearTargets()
        {
            _visualTarget.Clear();
        }

        public void SetTarget(Vector3 p, Collider c, float d, float t, TargetType tt)
        {
            _curTarget.Set(p, c, d, t, tt);
            _trigger.transform.position = _curTarget.GetPosition;
        }

        protected bool IsColliderVisible(Collider other)
        {
            Vector3 dir = other.transform.position - GetSensorPosition;
            float angle = Vector3.Angle(transform.forward, dir);

            if (angle > _fov * 0.5f) return false; //outside fov

            RaycastHit hit;
            if (Physics.Raycast(GetSensorPosition, dir.normalized, out hit,
                _sightRange * GetSensorRadius))
            {
                if (hit.collider == other) return true;
            }
            dir = Vector3.zero;
            return false;
        }

        private void OnDrawGizmos()
        {
            if(_sensor == null) return;

            Color color = new Color(1f, 0f, 0f, 0.7f);
            UnityEditor.Handles.color = color;

            Vector3 rotatedForward = Quaternion.Euler(0f, -_fov * 0.5f, 0f) * transform.forward;
            UnityEditor.Handles.DrawSolidArc(GetSensorPosition, Vector3.up, rotatedForward,
                _fov, GetSensorRadius * _sightRange);

        }
    }
}
