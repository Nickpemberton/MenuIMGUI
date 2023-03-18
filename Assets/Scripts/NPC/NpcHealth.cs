using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
    public class NpcHealth : MonoBehaviour
    {
        private int _health = 100;

        public void RemoveHealth(int damage)
        {
            _health -= damage;
        }

        private void Update()
        {
            if (_health <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}