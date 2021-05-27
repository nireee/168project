using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;
    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;
    public int Side;
    public bool rolled = false;

    private bool coroutineAllowed = true;

    // Use this for initialization
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
        Side = PlayerControl.finalSide;
        // Show final dice value in Console
        Debug.Log(PlayerControl.finalSide);
        coroutineAllowed = true;
    }
}
