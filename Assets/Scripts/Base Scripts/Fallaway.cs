using UnityEngine;

public class TimeDevice : MonoBehaviour
{
  public GameObject fallaway;

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      ActivateFallaway();

      Destroy(gameObject);
    }
  }

  void ActivateFallaway()
  {
    Rigidbody[] rbs = fallaway.GetComponentsInChildren<Rigidbody>();

    foreach (Rigidbody rb in rbs)
    {
      rb.useGravity = true;
      rb.isKinematic = false;
    }
  }
}