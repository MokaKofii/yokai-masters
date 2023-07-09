using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{
   public GameObject owner;

   [SerializeField]
   private string animationName;
   
   [SerializeField]
   private bool magicAttack; //A Checkbox for Mana. Planning on replacing this to a checkbox for hiragana questions later on

   [SerializeField]
   private float magicCost;

   [SerializeField]
   private float minAttackMultiplier;
   
   [SerializeField]
   private float maxAttackMultiplier;

   [SerializeField]
   private float minDefenseMultiplier;
   
   [SerializeField]
   private float maxDefenseMultiplier;

   [SerializeField]
   
   private FighterStats attackerStats;
   private FighterStats targetStats;
   private float damage = 0.0f;
   private float xMagicNewScale; //Dunno what these are, but related to MP i guess?
   private Vector2 magicScale;   //Related to MP Bar

   private void Start()
   {
        magicScale = GameObject.Find("PlayerMagicFill").GetComponent<RectTransform>().localScale;
   }
    
   public void Attack(GameObject victim) 
   {
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = victim.GetComponent<FighterStats>();
        if(attackerStats.magic >= magicCost)
        {
            float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);
            attackerStats.updateMagicFill(magicCost); //Updating MP Bar after heavy spell is casted
                                                     //Might be able to disable this once the quiz is working, idk

            damage = multiplier * attackerStats.lightspell;
            if (magicAttack)
            {
                damage = multiplier * attackerStats.heavyspell;
                attackerStats.magic = attackerStats.magic - magicCost;
            }

            float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
            damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));
            owner.GetComponent<Animator>().Play(animationName);
            targetStats.ReceiveDamage(damage);
        }
   }
}
