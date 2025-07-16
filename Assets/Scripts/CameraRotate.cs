using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    float mouseY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(transform.eulerAngles.x - mouseY, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
