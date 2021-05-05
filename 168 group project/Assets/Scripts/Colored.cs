using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colored : MonoBehaviour
{
    public SpriteRenderer sr;
    public Dice dice;
    public Transform[] areas;


    public int area_index = 0;

    public bool move = false; //for one player currently
    public float movespeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        sr = areas[area_index].GetComponent<SpriteRenderer>();
        transform.position = areas[area_index].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(move) Move();
        
        
    }

    void Move()
    {
        if (area_index <= areas.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            areas[area_index].transform.position,
            movespeed * Time.deltaTime);
            print("checked");
            if (transform.position == areas[area_index].transform.position)
            {
                area_index += 1;
            }
        }
    }
    public void ChangeColor()
    {
        
        sr.color = new Color(0, 1, 0, 1);
    }
}
