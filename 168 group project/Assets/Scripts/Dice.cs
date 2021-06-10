using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    public GameObject[] player;
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public int Side;
    public int Turns;
    public int Turns_length;
    public bool rolled = false;
    private bool coroutineAllowed = true;
    public int Rounds = 1;

    public void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        Turns = 0;
        Turns_length = 4;
	}
	
    public void OnMouseDown()
    {
        if(coroutineAllowed) StartCoroutine("RollTheDice");
        
    }

    public IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 5);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }
        PlayerControl.finalSide = randomDiceSide + 1;
        if (Turns == 0)
        {
            PlayerControl.MovePlayer(1);
            Turns += 1;
        }
        else if (Turns == 1)
        {
            PlayerControl.MovePlayer(2);
            Turns += 1;
        }
        else if (Turns == 2)
        {
            PlayerControl.MovePlayer(3);
            Turns += 1;
        }
        else if (Turns == 3)
        {
            PlayerControl.MovePlayer(4);
            Turns += 1;
        }
        else
        {
            Turns = 0;
            Rounds += 1;
            PlayerControl.MovePlayer(1);
            Turns += 1;
        }
        Side = PlayerControl.finalSide;
        Debug.Log(PlayerControl.finalSide);
        coroutineAllowed = true;
    }
}
