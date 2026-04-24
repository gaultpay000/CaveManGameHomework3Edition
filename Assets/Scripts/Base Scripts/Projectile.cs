using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    SphereCollider col;
    public bool collectable = false;
    void Start()
    {
        col = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.GetComponentInChildren<Enemy>() != null)
        {
            collision.gameObject.GetComponentInChildren<Enemy>().TakeDamage(19);
        }
        collectable = true;
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;
        col.isTrigger = true;
    }
}