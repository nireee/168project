using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static GameObject player;
    public static int player_start_index = 0;
    public static int finalSide = 0;
    public bool GameOver = false;
    void Start()
    {
        player = GameObject.Find("player");
        player.GetComponent<Colored>().move = false;
    }
    private void Update()
    {
        if (player.GetComponent<Colored>().area_index >
            player_start_index + finalSide)
        {
            player.GetComponent<Colored>().move = false;
            player_start_index = player.GetComponent<Colored>().area_index - 1;
        }

        if (player.GetComponent<Colored>().area_index >=
            player.GetComponent<Colored>().areas.Length)
        {
            player.GetComponent<Colored>().area_index -= player.GetComponent<Colored>().areas.Length;
        }
        
    }
    public static void MovePlayer()
    {
        player.GetComponent<Colored>().move = true;
    }
}
