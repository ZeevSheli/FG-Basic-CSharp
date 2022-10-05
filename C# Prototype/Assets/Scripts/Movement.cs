using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody character;
    [SerializeField] private float speed = 2f;
    private bool isGrounded;

    public float gravity = -10;
    public float turnSmoothVelocity; 
    public float turnSmoothTime;
    public CharacterController characterController;
    public GameObject player;
    public Transform cam;
    public Vector3 moveDir;
    public Vector3 direction;
    private float verticalVelocity;



    private Vector3 velocity;
    public float jump = 10f;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(player.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            player.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("yay");
            velocity.y = jump;
        }
        
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
            characterController.Move(velocity * Time.deltaTime);

}
    
     
    
    
    void IsGrounded()
    {
        RaycastHit hit;
        float distance = 3f;
        Vector3 direction = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, direction, out hit, distance))
        {
            isGrounded = true;

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
