using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScript : MonoBehaviour
{
    [SerializeField] private Transform destination;

    public Transform PortalDestination()
    {
        return destination;
    }
}
