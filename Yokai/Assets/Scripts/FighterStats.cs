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

   private void Start()
   {
        healthTransform = healthFill.GetComponent<RectTransform>();
        healthScale = healthFill.transform.localScale;

        magicTransform = healthFill.GetComponent<RectTransform>(); //Again, this might be erased if the Japanese quiz is successfully implemented
        magicScale = magicFill.transform.localScale; //Again, this might be erased if the Japanese quiz is successfully implemented

        startHealth = health;
        startMagic = magic; //Again, this might be erased if the Japanese quiz is successfully implemented
   }

   public void ReceiveDamage(float damage)
   {
        health = health - damage;
        animator.Play("Hurt");

        //Set damage text

        if(health < 1)
        {
            dead = true;
            gameObject.tag = "Dead";
            Destroy(healthFill);
            Destroy(gameObject);
        } else
        {
            xNewHealthScale = healthScale.x * (health / startHealth);
            healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        }
   }

   public void updateMagicFill(float cost)
   {
        magic = magic - cost;
        xNewMagicScale = magicScale.x * (magic / startMagic);
        magicFill.transform.localScale = new Vector2(xNewMagicScale, magicScale.y);
   }
   
   public int CompareTo(object otherStats)
   {
     int nex = nextActTurn.CompareTo(((FighterStats)otherStats).nextActTurn);
     return nex;
   }
}
