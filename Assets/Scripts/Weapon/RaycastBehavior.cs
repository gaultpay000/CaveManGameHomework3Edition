using UnityEngine;

public class RaycastBehavior : IWeaponBehavior
{
    public int range;
    public void Fire(Transform firePoint)
    {
        
        Debug.DrawRay(firePoint.position, firePoint.forward * range, Color.red, 1f);

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out RaycastHit hit, range, ~6))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.GetComponent<Enemy>() != null)
            {
                    hit.collider.GetComponent<Enemy>().TakeDamage(33);
            }
        }
       
        // if (Physics.Raycast(firePoint.position, firePoint.forward, out hit,  range, mask))
        // {
        //     Debug.Log(hit.transform);
        //     if (hit.transform.GetComponent<Enemy>() != null)
        //     {
        //         hit.transform.GetComponent<Enemy>().TakeDamage(33);
        //     }
        // }
    }
}
