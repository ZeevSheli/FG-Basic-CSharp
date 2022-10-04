using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody character;
    [SerializeField] private float speed = 2f;
    private bool isGrounded;
 
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"));
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded)
        {
            Jump();
            Debug.Log("Should jump here");
        }

        IsGrounded();
    }
    void IsGrounded()
    {
        RaycastHit hit;
        float distance = 3f;
        Vector3 direction = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, direction, out hit, distance))
        {
            isGrounded = true;
            Debug.Log("Grounded y'all!");

        }
        else
        {
            isGrounded = false;
        }
    }



    private void Jump()
    {
        character.AddForce(Vector3.up * 500f);
    }


}
