using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;

public class BiteAttack : MonoBehaviour
{
    public Transform target;
    private PlayerHandler _playerStats;
    void Start()
    {
        _playerStats = target.GetComponent<PlayerHandler>();
        _playerStats.Damage(5);
    }
}
