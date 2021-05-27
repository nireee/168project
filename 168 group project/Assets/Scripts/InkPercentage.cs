using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkPercentage : MonoBehaviour
{
    public Slider InkBar;
    public Dice dice;
    public int currentInk = 100;
    public GameObject[] map;
    public CharacterController player;
    public int cur_index;
    public float spend_rate = 1f;
    public float replenish_rate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InkBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.move == true)
        {
            cur_index += dice.Side;
            if (cur_index > map.Length)
            {
                cur_index -= map.Length;
            }
            print(cur_index);
            print(map[cur_index].GetComponent<SpriteRenderer>().color);
            ChangeInk();
        }
        InkBar.value = currentInk;
    }

    public void ChangeInk()
    {
        if (map[cur_index].GetComponent<SpriteRenderer>().color == player.Inkcolor)
        {
            currentInk += 6 * (int)replenish_rate;
        }
        else if (map[cur_index].GetComponent<SpriteRenderer>().color == Color.white)
        {
            currentInk -= 3 * (int)spend_rate;
        }
        else
        {
            currentInk -= 6 * (int)spend_rate;
        }
        if (currentInk > 100)
        {
            currentInk = 100;
        }
    }

    
    
}
