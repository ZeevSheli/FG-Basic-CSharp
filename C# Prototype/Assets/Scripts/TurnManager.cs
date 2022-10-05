
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;

    public int currentTurn;
    public int player1Turn = 1;
    public int player2Turn = 2;

    public GameObject player2;
    public Movement player2Movement;
    public Shoot player2Shoot;
    public GameObject player2Camera;
    public GameObject player2FreeLook;

    public GameObject player1;
    public Movement player1Movement;
    public Shoot player1Shoot;
    public GameObject player1Camera;
    public GameObject player1FreeLook;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        currentTurn = player1Turn;
        Player1Turn();
    }

   void Update()
    {
        if (currentTurn == 1 && Input.GetMouseButtonDown(0))
        {
            Player2Turn();
        }
        else if (currentTurn == 2 && Input.GetMouseButtonDown(0))
        {
            Player1Turn();
        }
    }
   void Player2Turn()
    {
        player2Movement.enabled = true;  
        player1Movement.enabled = false;

        player2FreeLook.SetActive(true);
        player1FreeLook.SetActive(false);

        player2Camera.SetActive(true);
        player1Camera.SetActive(false);

        currentTurn = 2;
    }

   void Player1Turn()
    {
        player1Movement.enabled = true;
        player2Movement.enabled = false;

        player1Shoot.enabled = true;
        player2Shoot.enabled = false;

        player1FreeLook.SetActive(true);
        player2FreeLook.SetActive(false);


        player2Camera.SetActive(false);
        player1Camera.SetActive(true);

        currentTurn = 1;
    }
}
