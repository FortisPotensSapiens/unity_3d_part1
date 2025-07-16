using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI count;
    PickUp pickUp;
    // Start is called before the first frame update
    void Start()
    {
        pickUp = GameObject.FindGameObjectWithTag("Player").GetComponent<PickUp>();
    }

    // Update is called once per frame
    void Update()
    {
        count.text = $"{pickUp.grib} grip";
    }
}
