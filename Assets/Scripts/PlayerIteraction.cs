using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIteraction : MonoBehaviour
{
    [SerializeField] GameObject ButtonE;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Chest")
        {
            ButtonE.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                var anim = other.gameObject.GetComponent<Animator>();
                var isOpen = anim.GetBool("isOpen");
                anim.SetBool("isOpen", !isOpen);
                ButtonE.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Chest")
        {
            ButtonE.SetActive(false);
        }
    }
}
