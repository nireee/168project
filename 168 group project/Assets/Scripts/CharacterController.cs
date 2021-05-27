using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Dice dice;
    public Transform[] areas;
    private Vector2 TargetPos;
    public int area_index = 0;
    public GameObject player;
    public Color Inkcolor;
    public GameObject[] map;
    public int ink_amount;
    private InkPercentage ink;
    public bool move = false; //for one player currently

    void Start()
    {
        ink_amount = ink.currentInk;
    }


    public void Update()
    {
        if (move)
        {
            print("dice rolled");
            area_index += dice.Side;
            Move();
            ChangeColor(area_index);
        }
        move = false;
        
        
    }

    public void Move()
    {
        if (area_index > areas.Length - 1)
        {
            area_index -= areas.Length;
        }
        TargetPos = new Vector2(areas[area_index].transform.position.x, areas[area_index].transform.position.y);
        print("TargetPos:"+ TargetPos);
        player.transform.position = TargetPos;
        print("CurrentPos:" + player.transform.position);
        
        
    }

    public void ChangeColor(int index)
    {
        SpriteRenderer sr = map[index].GetComponent<SpriteRenderer>();
        sr.color = Inkcolor;
        print("Colorchanged");
    }

    
    
}
