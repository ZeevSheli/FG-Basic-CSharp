using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pcMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float playerSpeed = 3.0f;
    public float smoothTurn = 0.1f;
  
    float smoothTurnVel;

    public bool groundedPlayer;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;

    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        //make sure the character controller do not move on the z axis
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;   

        //the code below will have the player smoothly move and look in the correct way
            if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg * cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothTurnVel, smoothTurn);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
        }
    }
}
