using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FighterStats : MonoBehaviour, IComparable
{
   [SerializeField]
   private Animator animator;

   [SerializeField]
   private GameObject healthFill;

   [SerializeField]
   private GameObject magicFill; //Again, this might be erased if the Japanese quiz is successfully implemented

   [Header("Stats")]
   public float health;
   public float magic;
   public float lightspell;
   public float heavyspell;
   public float defense;
   public float speed; //Might be replaced with accuracy?
   public float experience;

   private float startHealth;
   private float startMagic; //Again, this might be erased if the Japanese quiz is successfully implemented

   [HideInInspector]
   public int nextActTurn;

   public bool dead = false;

   private Transform healthTransform;
   private Transform magicTransform; //Again, this might be erased if the Japanese quiz is successfully implemented

   private Vector2 healthScale;
   private Vector2 magicScale; //Again, this might be erased if the Japanese quiz is successfully implemented

   private float xNewHealthScale;
   private float xNewMagicScale;

   private GameObject GameControllerObj;

   void Awake()
   {
        healthTransform = healthFill.GetComponent<RectTransform>();
        healthScale = healthFill.transform.localScale;

        magicTransform = healthFill.GetComponent<RectTransform>(); //Again, this might be erased if the Japanese quiz is successfully implemented
        magicScale = magicFill.transform.localScale; //Again, this might be erased if the Japanese quiz is successfully implemented

        startHealth = health;
        startMagic = magic; //Again, this might be erased if the Japanese quiz is successfully implemented

        GameControllerObj = GameObject.Find("GameControllerObject");
   }

   public void ReceiveDamage(float damage)
   {
        health = health - damage;
        animator.Play("Hurt");

        //Set damage text

        if(health <= 0)
        {
            dead = true;
            gameObject.tag = "Dead";
            Destroy(healthFill);
            Destroy(gameObject);
        } else if (damage > 0)
        {
            xNewHealthScale = healthScale.x * (health / startHealth);
            healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        }
        if(damage > 0)
        {
        GameControllerObj.GetComponent<GameController>().battleText.gameObject.SetActive(true);
        GameControllerObj.GetComponent<GameController>().battleText.text = damage.ToString();
        }
        Invoke("ContinueGame", 2);
   }

   public void updateMagicFill(float cost)
   {
        if(cost > 0)
        {
        magic = magic - cost;
        xNewMagicScale = magicScale.x * (magic / startMagic);
        magicFill.transform.localScale = new Vector2(xNewMagicScale, magicScale.y);
        }

   }
   
   public bool GetDead()
   {
     return dead;
   }

   void ContinueGame()
   {
     GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
   }

   public void CalculateNextTurn(int currentTurn)
   {
     nextActTurn = currentTurn + Mathf.CeilToInt(100f / speed);
   }

   public int CompareTo(object otherStats)
   {
     int nex = nextActTurn.CompareTo(((FighterStats)otherStats).nextActTurn);
     return nex;
   }
}
