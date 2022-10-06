
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;

    public int currentTurn;
    public int player1Turn = 1;
    public int player2Turn = 2;

    public GameObject player2;
    public Movement player2Movement;
    public GameObject player2Camera;
    public GameObject player2FreeLook;
    public GameObject player2Gun;

    public GameObject player1;
    public Movement player1Movement;
    public GameObject player1Camera;
    public GameObject player1FreeLook;
    public GameObject player1Gun;

    private bool isCoroutineExecuting = false;

    public bool hasShot = false;

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
        StartCoroutine(Player1Turn());
    }

    void Update()
    {
        if (currentTurn == 1 && !isCoroutineExecuting && hasShot)
        {
            StartCoroutine(Player2Turn());
        }
        else if (currentTurn == 2 && !isCoroutineExecuting && hasShot)
        {
            StartCoroutine(Player1Turn());
        }
    }

    IEnumerator Player2Turn()
    {
        isCoroutineExecuting = true;
        hasShot = false;

        player1Movement.enabled = false;
        player1Gun.SetActive(false);

        yield return new WaitForSeconds(1f);

        player2Movement.enabled = true;
        player2Gun.SetActive(true);

        player2FreeLook.SetActive(true);
        player1FreeLook.SetActive(false);

        player2Camera.SetActive(true);
        player1Camera.SetActive(false);

        currentTurn = 2;

        isCoroutineExecuting = false;
    }

    IEnumerator Player1Turn()
    {
        isCoroutineExecuting = true;
        hasShot = false;

        player2Movement.enabled = false;
        player2Gun.SetActive(false);

        yield return new WaitForSeconds(1f);

        player1Movement.enabled = true;
        player1Gun.SetActive(true);

        player1FreeLook.SetActive(true);
        player2FreeLook.SetActive(false);


        player2Camera.SetActive(false);
        player1Camera.SetActive(true);

        currentTurn = 1;

        isCoroutineExecuting = false;
    }
}
