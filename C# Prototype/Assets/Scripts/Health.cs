using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int MaxHealth = 3;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public GameObject Player2Win;
    public GameObject Player1Win;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;

        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);

        Player1Win.SetActive(false);
        Player2Win.SetActive(false);


    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("projectile") && currentHealth >= 2)
            {
               currentHealth--;
               DisplayHealth();
            }
            else if (other.CompareTag("projectile") && currentHealth <= 1)
            {
               Die();
            }
        }

    void DisplayHealth()
    {
        if (currentHealth == 2)
        {
            heart3.SetActive(false);
        }
        else if (currentHealth == 1)
        {
            heart2.SetActive(false);
        }
        else if (currentHealth == 0)
        {
             heart1.SetActive(false);
        }

    }

    void Die()
    {
            if (this.tag == "Player1")
            {
        Debug.Log("Player2 wins!");
            }
           if (this.tag == "Player2")
            {
        Debug.Log("Player1 wins!");
            }
    
        Time.timeScale = 0;
    }


}

