using UnityEngine;
using UnityEngine.Events;

public class AudioLogCollector : MonoBehaviour
{
    public UnityEvent AudioLogCollected;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AudioLogCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
