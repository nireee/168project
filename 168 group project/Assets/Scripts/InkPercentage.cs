using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkPercentage : MonoBehaviour
{
    public Slider InkBar;
    public Text percentage;
    public Dice dice;
    public int currentInk;
    public GameObject[] map;
    public CharacterController player;
    public float spend_rate = 2f;
    public float replenish_rate = 2f;

    void Start()
    {
        InkBar = GetComponent<Slider>();
        currentInk = 100;
    }

    void Update()
    {
        InkBar.value = currentInk;
        percentage.text = currentInk + "%";
    }

    public void ChangeInk()
    {
        Debug.Log(player.area_index);
        if (map[player.area_index].GetComponent<SpriteRenderer>().color == player.Inkcolor)
        {
            Debug.Log("replenish");
            currentInk += 2 * (int)replenish_rate;
        }
        else if (map[player.area_index].GetComponent<SpriteRenderer>().color == Color.white)
        {
            Debug.Log("color white");
            currentInk -= 1 * (int)spend_rate;
        }
        else
        {
            Debug.Log("step on others");
            currentInk -= 2 * (int)spend_rate;
        }
        if (currentInk > 100)
        {
            currentInk = 100;
        }
        if(currentInk < 0)
        {
            currentInk = 0;
        }
    }  
}
