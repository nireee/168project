using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    public GameObject[] player;
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public int Side;
    public int Turns;
    public bool rolled = false;
    private bool coroutineAllowed = true;

    public void Start () {

        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
	}
	
    // If you left click over the dice then RollTheDice coroutine is started
    public void OnMouseDown()
    {
        if(coroutineAllowed) StartCoroutine("RollTheDice");
        
    }

    // Coroutine that rolls the dice
    public IEnumerator RollTheDice()
    {
        coroutineAllowed = false;

        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, 5);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        PlayerControl.finalSide = randomDiceSide + 1;
        PlayerControl.MovePlayer();

        //Turns = 0;
        //if(Turns == 0)
        //{
        //    PlayerControl.MovePlayer(1);
        //}
        //else if(Turns == 1)
        //{
        //    PlayerControl.MovePlayer(2);
        //}
        //else if (Turns == 2)
        //{
        //    PlayerControl.MovePlayer(3);
        //}
        //else if (Turns == 3)
        //{
        //    PlayerControl.MovePlayer(4);
        //}
        //else
        //{
        //    if(Turns > 3) Turns = 0;
        //}
        //Turns += 1;

        Side = PlayerControl.finalSide;
        // Show final dice value in Console
        Debug.Log(PlayerControl.finalSide);
        coroutineAllowed = true;
    }
}
