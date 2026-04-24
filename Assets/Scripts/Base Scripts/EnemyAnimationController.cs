using System.Collections;
using AICore;
using BehaviorTree;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    Animator animator;

    [SerializeField]BTAgent agent;
    [Range(-1f, 1f)] public float _horizontal;
    [Range(-1f, 1f)] public float _vertical;
    public bool waiting = false;

    bool isKicking = false;

    public bool SetIsKicking { set { isKicking = value; } }

    public bool SetIsWaiting { set{ waiting = value; } }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.GetCurrTarget.GetTargetType == TargetType.Visual && !waiting)
        {
            _horizontal = 2f;
        }
        else if (agent.GetCurrTarget.GetTargetType == TargetType.Waypoint && !waiting)
        {
            _horizontal = 1f;
        }
        else if (waiting)
        {
            _horizontal = 0f;
        }
        if (!isKicking)
        {
            _vertical = 0f;
        }
        animator.SetFloat("h", _horizontal);
        animator.SetFloat("v", _vertical);
    }

    public IEnumerator Kick()
    {
        if (!isKicking) 
        {
            isKicking = true;
            _vertical = 1f;
            yield return new WaitForSeconds(0.5f);
            _horizontal = 0f;
            isKicking = false;
        }
    }
}
