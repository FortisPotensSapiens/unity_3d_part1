using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerIteraction : MonoBehaviour
{
    [SerializeField] GameObject ButtonE;
    [SerializeField] Animation OpenAnim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Chest")
        {
            ButtonE.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Chest")
        {
            if (Input.GetKey(KeyCode.E))
            {
                StartCoroutine(Win(other));
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

    IEnumerator Win(Collider other)
    {
        var anim = other.gameObject.GetComponent<Animator>();
        var isOpen = anim.GetBool("isOpen");
        anim.SetBool("isOpen", !isOpen);
        ButtonE.SetActive(false);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
