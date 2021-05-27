using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbilities : MonoBehaviour
{
    public CharacterController player;
    public InkPercentage ink_value;
    public Dice dice;
    public GameObject[] map;
    public CharacterController enemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Inkpot()
    {
        ink_value.currentInk += 10;
    }

    public void Blast()
    {
        player.ChangeColor(player.area_index + 1);
        player.ChangeColor(player.area_index - 1);
    }

    public void Overuse()
    {
        ink_value.spend_rate = 2f;
    }

    public void Conserve()
    {
        ink_value.spend_rate = 0.5f;
    }

    public void Turn()
    {
        player.dice.Side = -player.dice.Side;
    }

    public void Freeze()
    {
        player.move = false;
    }

    public void FiftyFifty()
    {
        //not completed
        int ink_t = (enemy.ink_amount + player.ink_amount) / 2;
        enemy.ink_amount = ink_t;
        player.ink_amount = ink_t;
    }

    public void Lucky()
    {
        ink_value.replenish_rate = 2f;
    }

    public void UnLucky()
    {
        ink_value.replenish_rate = 0.5f;
    }

    public void Friendship()
    {
        ink_value.spend_rate = 0f;
        ink_value.replenish_rate = 0.5f;
    }

    public void Stimulant()
    {
        //not completed
    }

}