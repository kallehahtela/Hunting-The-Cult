using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform player;
    Vector3 vector;

    void Update()
    {
        vector.z = player.eulerAngles.y;
        transform.localEulerAngles = vector;
    }
}
