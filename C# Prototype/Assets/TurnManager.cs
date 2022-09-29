using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    public TurnManager instance;
    bool player1_Activate;
    bool player2_Activate;
    public TurnManager Instance { get => instance; set => instance = value; }

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
    }
        else
        {
            instance = this;
        }
    }

    void Start()

    {
        player1.SetActive(true);
    }


    void SwitchTurn()
    {
        if (player1.activeInHierarchy)
        {
            player1.SetActive(false);
            player2.SetActive(true);
            
        }
        else if (player2.activeInHierarchy)
        {
            player2.SetActive(false);
            player1.SetActive(true);

        }
    }

}
