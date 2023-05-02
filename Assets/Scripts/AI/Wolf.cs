using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : EnemyBase
{
    public override void Start()
    {
        rend = gameObject.transform.GetChild(0).GetComponent<Renderer>();
        Debug.Log("Test");
        Difficulty();
        Debug.Log("Test 2");
        walkSpeed = 1 + difficulty;
        runSpeed = 2 + difficulty;
        base.Start();
    }
    public override void Update()
    {
        base.Update();
    }
    public void BiteAttack()
    {
        int critChance = Random.Range(1,21);
        float critDamage = 0;
        if (critChance >= 20-difficulty)
        {
            critDamage = Random.Range(baseDamage/2,baseDamage * difficulty);
        }
        player.GetComponent<PlayerHandler>().Damage(baseDamage * difficulty + critDamage);
    }
}
