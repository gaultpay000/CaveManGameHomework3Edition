using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
    public class WaitAction : BTActionNodeBase
    {
        public Vector2 waitDuration;
        public WaitType waitType;
        public EnemyAnimationController animController;

        float _value;
        float _startTime;

        public enum WaitType
        {
            SetDuration,
            RandomDuration
        }

        protected override void OnStart()
        {
            if (waitType == WaitType.SetDuration)
            {
                _value = waitDuration.x;
            }
            else _value = Random.Range(waitDuration.x, waitDuration.y);
            
            _startTime = Time.time;

            animController = FindAnyObjectByType<EnemyAnimationController>();

            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            return (Time.time - _startTime) >= _value ? State.Success : State.Running;
        }
    }
}