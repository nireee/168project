using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static GameObject player1, player2, player3, player4;
    public static int player_start_index = 0;
    public static int finalSide = 0;
    public int Steps;
    public bool GameOver = false;
    void Start()
    {
        player1 = GameObject.Find("Cuttlefish_0");
        player2 = GameObject.Find("Cuttlefish_1");
        player3 = GameObject.Find("Cuttlefish_2");
        player4 = GameObject.Find("Cuttlefish_3");

        player1.GetComponent<CharacterController>().move = false;
        player2.GetComponent<CharacterController>().move = false;
        player3.GetComponent<CharacterController>().move = false;
        player4.GetComponent<CharacterController>().move = false;
    }
    private void Update()
    {

    }
    public static void MovePlayer()
    {
        //if(player == player1)
        //{
        //    player1.GetComponent<CharacterController>().move = true;
        //}
        //else if (player == player2)
        //{
        //    player2.GetComponent<CharacterController>().move = true;
        //}
        //else if (player == player3)
        //{
        //    player3.GetComponent<CharacterController>().move = true;
        //}
        //else if (player == player4)
        //{
        //    player4.GetComponent<CharacterController>().move = true;
        //}

    }

    //public void PersonalFight()
    //{

    //}

    //public void TeamFight()
    //{

    //}


}
