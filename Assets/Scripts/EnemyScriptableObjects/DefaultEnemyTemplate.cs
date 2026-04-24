using UnityEngine;
using XNode;

[CreateAssetMenu(fileName = "DefaultEnemyTemplate", menuName = "Scriptable Objects/DefaultEnemyTemplate")]
public class DefaultEnemyTemplate : ScriptableObject
{
    public string enemyName = "enemy";
    public const int enemyMaxHealth = 100;
    [Range(0, enemyMaxHealth)]public int enemyHealth;

    public enum EnemyType
    {
        Melee,
        Ranged,
        Boss
    }
    public EnemyType enemyType;

    public NodeGraph behaviorTree = null;

    
}
