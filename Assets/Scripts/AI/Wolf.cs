using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : EnemyBase
{
    
    void BiteAttack()
    {
        int critChange = Random.Range(1,21);
        float critDamage = 0;
        if (critChange >= 20 - difficulty)
        {
            critDamage = Random.Range(baseDamage/2, baseDamage * difficulty);
        }
        player.GetComponent<PlayerHandler>().Damage(baseDamage * difficulty + critDamage);
    }
}
