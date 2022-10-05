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


    void OnTriggerEnter(Collider collider)
        {
            if (collider.CompareTag("Bullet") && currentHealth >= 2)
            {
                Debug.Log("Hurt");
                currentHealth--;
            }
            else if (collider.CompareTag("Bullet") && currentHealth <= 1)
            {
               Die();
            }

        DisplayHealth();
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
            Player2Win.SetActive(true);
            Time.timeScale = 0;
        }
        if (this.tag == "Player2")
        {
            Debug.Log("Player1 wins!");
            Player1Win.SetActive(true);
            Time.timeScale = 0;
        }

      
    }


}
