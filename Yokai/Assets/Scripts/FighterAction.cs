using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAction : MonoBehaviour
{
    private GameObject player;
    private GameObject enemysnake;

    [SerializeField]
    private GameObject lightspellPrefab;

    [SerializeField]
    private GameObject heavyspellPrefab;

    [SerializeField]
    private Sprite faceIcon;

    private GameObject currentAttack;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemysnake = GameObject.FindGameObjectWithTag("EnemySnake");
    }

    public void SelectAttack(string btn)
    {
        GameObject victim = player;
        if(tag == "Player")
        {
            victim = enemysnake;
        }
        if(btn.CompareTo("light") == 0)
        {
            lightspellPrefab.GetComponent<MoveScript>().Attack(victim);
        } else if(btn.CompareTo("heavy") == 0)
        {
            heavyspellPrefab.GetComponent<MoveScript>().Attack(victim);
        } else
        {
            Debug.Log("Run");
        }
    }
}
