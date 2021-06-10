using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesSetter : MonoBehaviour
{
    public int num_to_set;
    public List<GameObject> abilities;
    public Transform[] areas;
    public bool ability_exist;
    public int current_num_abilities;
    public CharacterController[] players;
    public List<int> index;
    public List<GameObject> DisplayedAbilities;
    public int random_pos = 0;
    public List<int> item_index;
    public SpecialAbilities sa;
    public int Abilities_index;
    public int player_index;

    void Start()
    {
        SetAbilities();
        ability_exist = false;
    }
    public void SetAbilities()
    {
        item_index.Clear();
        index.Clear();
        DisplayedAbilities.Clear();
        int random_item = 0;
        GameObject toSet;
        float pos_x, pos_y;
        Vector2 pos;
        for(int i = 0; i < num_to_set; i++)
        {
            random_item = Random.Range(0, abilities.Count);
            item_index.Add(random_item);
            toSet = abilities[random_item];
            CheckDuplicatePos();
            pos_x = areas[random_pos].position.x;
            pos_y = areas[random_pos].position.y;
            pos = new Vector2(pos_x, pos_y);
            GameObject ab = Instantiate(toSet, pos, toSet.transform.rotation) as GameObject;
            DisplayedAbilities.Add(ab);
        }
        current_num_abilities = num_to_set;
        Debug.Log("finish setting abilities");
    }

    private void CheckDuplicatePos()
    {
        random_pos = Random.Range(1, 31);
        if (index.Contains(random_pos))
        {
            CheckDuplicatePos();
            Debug.Log("DuplicatePos Detected");
        }
        else
        {
            index.Add(random_pos);
        }
    }

    public void ActivateAbility()
    {
        for(int i = 0; i < players.Length; i++)
        {
            if (index.Contains(players[i].area_index))
            {
                int j = index.IndexOf(players[i].area_index);
                Destroy(DisplayedAbilities[j]);
                DisplayedAbilities.RemoveAt(j);
                Abilities_index = item_index[j];
                player_index = i;
                ChooseAbility();
                current_num_abilities -= 1;
                index.Remove(players[i].area_index);
                item_index.RemoveAt(j);
            }
        }

    }

    public void ChooseAbility()
    {
        if (Abilities_index == 0)
        {
            sa.Blast();
        }
        else if (Abilities_index == 1)
        {
            sa.Conserve();
        }
        else if (Abilities_index == 2)
        {
            sa.Inkpot();
        }
        else if (Abilities_index == 3)
        {
            sa.Lucky();
        }
        else if (Abilities_index == 4)
        {
            sa.Overuse();
        }
        else if (Abilities_index == 5)
        {
            sa.UnLucky();
        }
        else if(Abilities_index == 6)
        {
            sa.LoseInk();
        }
    }

    public void CheckAbilitiesExist()
    {
        if (current_num_abilities != 0) ability_exist = true;
        else ability_exist = false;
    }
}
