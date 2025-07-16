using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController controller;
    float hor;
    float ver;
    float speed = 10f;
    Vector3 inputDirection;
    float mouseX;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");
        mouseX = Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + mouseX, transform.eulerAngles.z);
        inputDirection = new Vector3(hor * speed * Time.deltaTime, 0, ver * speed * Time.deltaTime);
        inputDirection = transform.TransformDirection(inputDirection);
        controller.Move(inputDirection);
        if (ver != 0)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }
}
