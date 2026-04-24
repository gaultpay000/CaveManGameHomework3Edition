using UnityEngine;

namespace AICore
{
    [System.Serializable]
    public class Target
    {
        private Vector3 _pos;
        private Collider _collider;
        private float _distance;
        private float _time;
        [SerializeField] private TargetType _targetType;

        public Vector3 GetPosition { get { return _pos; } }
        public Collider GetCollider { get { return _collider; } }
        public float Distance { get { return _distance; } set { _distance = value; } }
        public float GetTime { get { return _time; } }
        public TargetType GetTargetType { get { return _targetType; } }

        public void Set(Vector3 p, Collider c, float d, float t, TargetType tt)
        {
            _pos = p;
            _collider = c;
            _distance = d;
            _time = t;
            _targetType = tt;
        }

        public void Clear()
        {
            _pos = Vector3.zero;
            _collider = null;
            _distance = float.MaxValue;
            _time = 0;
            _targetType= TargetType.None;
        }
    }

    public enum TargetType
    {
        None,
        Visual,
        Waypoint
    }
}
