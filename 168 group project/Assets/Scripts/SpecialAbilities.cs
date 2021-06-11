using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbilities : MonoBehaviour
{
    public CharacterController[] players;
    public InkPercentage[] ink_value;
    public AbilitiesSetter ab;
    public Dice dice;
    public GameObject[] map;
    public GameObject[] abilities;
    public int PlayerIndex;


    public void Inkpot()
    {
        GoBackToDefault();
        ink_value[PlayerIndex].currentInk += 10;
        if(ink_value[PlayerIndex].currentInk >= 100)
        {
            ink_value[PlayerIndex].currentInk = 100;
        }
        Debug.Log("Inkpot");
    }

    public void LoseInk()
    {
        GoBackToDefault();
        ink_value[PlayerIndex].currentInk -= 10;
        if (ink_value[PlayerIndex].currentInk >= 100)
        {
            ink_value[PlayerIndex].currentInk = 100;
        }
        Debug.Log("LoseInk");
    }

    public void Blast()
    {
        GoBackToDefault();
        SpriteRenderer sr1 = map[players[PlayerIndex].area_index + 1].GetComponent<SpriteRenderer>();
        sr1.color = players[PlayerIndex].Inkcolor;
        SpriteRenderer sr2 = map[players[PlayerIndex].area_index - 1].GetComponent<SpriteRenderer>();
        sr2.color = players[PlayerIndex].Inkcolor;
        Debug.Log("Blast");
    }

    public void Overuse()
    {
        GoBackToDefault();
        ink_value[PlayerIndex].spend_rate = 4.0f;
        Debug.Log("Overuse");
    }

    public void Conserve()
    {
        GoBackToDefault();
        ink_value[PlayerIndex].spend_rate = 1.0f;
        Debug.Log("Conserve");
    }

    public void Lucky()
    {
        GoBackToDefault();
        ink_value[PlayerIndex].replenish_rate = 4.0f;
        Debug.Log("Lucky");
    }

    public void UnLucky()
    {
        GoBackToDefault();
        ink_value[PlayerIndex].replenish_rate = 1.0f;
        Debug.Log("UnLucky");
    }

    public void GoBackToDefault()
    {
        PlayerIndex = ab.player_index;
        ink_value[PlayerIndex].replenish_rate = 2.0f;
        ink_value[PlayerIndex].spend_rate = 2.0f;
    }
}