using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour
{
    #region Structs

    [Serializable]
    public struct Attribute
    {
        public string name; // name of the attribute
        public float currentValue; // current val of attribute
        public float maxValue; // max value
        public float regenValue; // regen value eg heal over time from spell or potion
        public Image displayImage; // the bar that displays this fill amount eg health bar
    }
    #endregion

    #region Variables

    public Attribute[] attributes = new Attribute[3];
    public bool isDamaged;
    public bool canHeal;
    public bool isDead;
    public float healDelayTimer;

    #endregion

    public virtual void RegenOverTime(int attributeIndex)
    {
        // regen chosen attribute by its regen amount over time
        attributes[attributeIndex].currentValue += Time.deltaTime * attributes[attributeIndex].regenValue;
    }

    public virtual void Damage(float damage)
    {
        // will use this to trigger players screen to flash red later
        isDamaged = true;
        // reduce the health by the amount we are damaged
        attributes[0].currentValue -= damage;
        // delay and healing regen
        canHeal = false;
        healDelayTimer = 0;
        // check if we should be dead and set dead if needed
        if (attributes[0].currentValue <= 0 && !isDead)
        {
            Death();
        }

    }

    public virtual void Death()
    {
        isDead = true;
    }


    public virtual void Update()
    {
        #region Attributes Display

        for (int i = 0; i < attributes.Length; i++)
        {
            // divides current by max to get a percent, and then clamps between 0 and 1, and sets to fill amount
            attributes[i].displayImage.fillAmount = Mathf.Clamp01(attributes[i].currentValue / attributes[i].maxValue);
        }


        #endregion

        #region Can Heal

        if (!canHeal) // if we can't heal
        {
            healDelayTimer += Time.deltaTime; 
            if (healDelayTimer >= 5)
            {
                canHeal = true; // can heal
            }
        }

        if (canHeal && attributes[0].currentValue < attributes[0].maxValue && attributes[0].currentValue > 0) // if we can heal and are injured but not dead at 0
        {
            RegenOverTime(0); // trigger regen over time for health.
        }


        #endregion
    }

}
