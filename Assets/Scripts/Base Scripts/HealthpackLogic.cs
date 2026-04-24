using UnityEngine;
using UnityEngine.Events;

public class HealthpackLogic : MonoBehaviour
{
    public UnityEvent<float> ChangePlayerHP;
    public float restoreAmount;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ChangePlayerHP?.Invoke(restoreAmount);
            Destroy(gameObject);
        }

    }
}
