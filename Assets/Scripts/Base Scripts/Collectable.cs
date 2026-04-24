using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum PickUp
    {
        raycast,
        instantiate,
        arrow,
        log,
        smallHealth,
        largeHealth
    }

    public PickUp pickUp;
}