using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float grib = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            grib++;
            Debug.Log(grib);
            Destroy(other.gameObject);
        }
    }
}
