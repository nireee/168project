using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class PlayerControl : MonoBehaviour
{

    public static GameObject player1, player2, player3, player4;
    public static int player_start_index = 0;
    public static int finalSide = 0;
    public TextMeshProUGUI win;
    public TextMeshProUGUI area_count;
    public string winner;
    public bool GameOver = false;
    public AbilitiesSetter ABS;
    public GameObject[] map;
    public GameObject Panel;
    public CharacterController[] players;
    public int[] areas_captured;
    public GameObject Status;
    private IEnumerator coroutine;
    void Start()
    {
        player1 = GameObject.Find("Cuttlefish_0");
        player2 = GameObject.Find("Cuttlefish_1");
        player3 = GameObject.Find("Cuttlefish_2");
        player4 = GameObject.Find("Cuttlefish_3");
        player1.GetComponent<CharacterController>().ink_amount = 100;
        player2.GetComponent<CharacterController>().ink_amount = 100;
        player3.GetComponent<CharacterController>().ink_amount = 100;
        player4.GetComponent<CharacterController>().ink_amount = 100;

        for (int i = 0; i < 4; i++)
        {
            players[i].move = false;
        }
        Panel.SetActive(false);
    }
    private void Update()
    {
        ABS.CheckAbilitiesExist();
        if (!ABS.ability_exist)
        {
            ABS.SetAbilities();
        }
        ABS.ActivateAbility();
        CheckGameEnd();
        if (GameOver == true)
        {
            GameEnd();
        }

    }
    public static void MovePlayer(int playerIndex)
    {
        if (playerIndex == 1)
        {
            player1.GetComponent<CharacterController>().move = true;
        }
        else if (playerIndex == 2)
        {
            player2.GetComponent<CharacterController>().move = true;
        }
        else if (playerIndex == 3)
        {
            player3.GetComponent<CharacterController>().move = true;
        }
        else if (playerIndex == 4)
        {
            player4.GetComponent<CharacterController>().move = true;
        }

    }

    public void CheckResult()
    {
        for(int i = 0; i < 32; i++)
        {
            if(map[i].GetComponent<SpriteRenderer>().color == player1.GetComponent<CharacterController>().Inkcolor)
            {
                areas_captured[0] += 1;
            }
            else if (map[i].GetComponent<SpriteRenderer>().color == player2.GetComponent<CharacterController>().Inkcolor)
            {
                areas_captured[1] += 1;
            }
            else if (map[i].GetComponent<SpriteRenderer>().color == player3.GetComponent<CharacterController>().Inkcolor)
            {
                areas_captured[2] += 1;
            }
            else if (map[i].GetComponent<SpriteRenderer>().color == player4.GetComponent<CharacterController>().Inkcolor)
            {
                areas_captured[3] += 1;
            }
            else
            {
                continue;
            }
        }
    }

    public void GameEnd()
    {
        CheckResult();
        CheckWinner();
        area_count.text = "Player 1 :" + player1.GetComponent<CharacterController>().ink_amount + "% " + "Player 2 :" + player2.GetComponent<CharacterController>().ink_amount + "% " + "Player 3 :" + player3.GetComponent<CharacterController>().ink_amount + "% " + "Player 4 :" + player4.GetComponent<CharacterController>().ink_amount + "%";
        win.text = winner + " WINS!";
        Status.SetActive(false);
        Panel.SetActive(true);
        StartCoroutine(ChangeAfter15SecondsCoroutine());
        
    }
    private IEnumerator ChangeAfter15SecondsCoroutine()
    {
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public string CheckWinner()
    {
        int max_ink = Mathf.Max(player1.GetComponent<CharacterController>().ink_amount, player2.GetComponent<CharacterController>().ink_amount, player3.GetComponent<CharacterController>().ink_amount, player4.GetComponent<CharacterController>().ink_amount);
        if(max_ink == player1.GetComponent<CharacterController>().ink_amount)
        {
            winner = "Player 1";
        }
        else if (max_ink == player2.GetComponent<CharacterController>().ink_amount)
        {
            winner = "Player 2";
        }
        else if (max_ink == player3.GetComponent<CharacterController>().ink_amount)
        {
            winner = "Player 3";
        }
        else if (max_ink == player4.GetComponent<CharacterController>().ink_amount)
        {
            winner = "Player 4";
        }
        return winner;
    }

    public void CheckGameEnd()
    {
        if(player1.GetComponent<CharacterController>().ink_amount <= 0)
        {
            GameOver = true;
        }
        else if(player2.GetComponent<CharacterController>().ink_amount <= 0)
        {
            GameOver = true;
        }
        else if (player3.GetComponent<CharacterController>().ink_amount <= 0)
        {
            GameOver = true;
        }
        else if (player4.GetComponent<CharacterController>().ink_amount <= 0)
        {
            GameOver = true;
        }
        else
        {
            GameOver = false;
        }
    }


}
