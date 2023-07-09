using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateButton : MonoBehaviour
{
    [SerializeField]
    private bool spelllone;

    private GameObject player;
    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void AttachCallback(string btn)
    {
    
        if (btn.CompareTo("LightSpellBtn") == 0)
        {
            player.GetComponent<FighterAction>().SelectAttack("light");
        }   else if (btn.CompareTo("HeavySpellBtn") == 0)
        {
            player.GetComponent<FighterAction>().SelectAttack("heavy");
        }   else
        {
            player.GetComponent<FighterAction>().SelectAttack("run");
        }
    }
}
