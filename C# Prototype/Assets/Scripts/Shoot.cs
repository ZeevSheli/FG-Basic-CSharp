using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bullet;
    public float launchVelocityY;
    public float launchVelocityZ;


    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    
     void Shooting()
        {
            GameObject projectile = Instantiate(bullet, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocityY, launchVelocityZ));
        }
    
    }
}
