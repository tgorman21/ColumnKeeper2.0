using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCollider : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                if (other.GetComponent<Enemy>() != null)
                {
                    if (other.GetComponent<Enemy>().enemyName != Enemy.EnemyName.Carrier)
                    {
                        if (other.GetComponent<Enemy>().enemyName == Enemy.EnemyName.Derzin || other.GetComponent<Enemy>().enemyName == Enemy.EnemyName.Troll)
                        {
                            other.GetComponent<DerzinAttack>().activated = true;
                            other.GetComponent<Enemy>().animationType = Enemy.AnimationType.Throw;
                        }
                        other.GetComponent<EnemyAI>().currentState = EnemyAI.BehaviorState.SeekTower;
                    }
                }
            }
        }
    }
