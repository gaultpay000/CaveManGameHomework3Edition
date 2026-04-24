using System.Collections;
using UnityEngine;

public class Club : MonoBehaviour
{
    [SerializeField]PlayerMovement player;
    bool isLaunchable = false;
    [SerializeField]bool coroutineIsRunning = false;
    [SerializeField]float timeToRun;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.clubPos.transform.position;
        //Launch();
    }

    public void Launch()
    {
        if (/*Input.GetMouseButton(0) &&*/ isLaunchable)
        {
            Vector3 direction = player.transform.position - transform.position;
            timeToRun = Time.time;
            player.rb.linearDamping = 1;
            //player.isMovingUp = true;

            if (!coroutineIsRunning)
            {
                StartCoroutine(ClubSmoother(timeToRun, direction));
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isLaunchable = false;
    }
    void OnTriggerEnter(Collider other)
    {
        isLaunchable = true;
    }

    IEnumerator ClubSmoother(float timer, Vector3 direction)
    {
        coroutineIsRunning = true;
        while (timer > Time.time - 1)
        {
            player.rb.AddForce(direction * 8, ForceMode.Impulse);
            yield return new WaitForSeconds(.1f);
        }
        coroutineIsRunning = false;
        StopCoroutine(ClubSmoother(timer, direction));

    }
}
