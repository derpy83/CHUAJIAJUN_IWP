using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtk : MonoBehaviour
{
    public Transform Attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDmg = 5;

    private Animator enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EnemyAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Attackpoint.position, attackrange, enemyLayers);
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            Collider2D enemy = hitEnemies[i];
            enemy.GetComponent<Player_Health>().takeDmg(attackDmg);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (Attackpoint == null)
            return;
        Gizmos.DrawWireSphere(Attackpoint.position, attackrange);
    }
}

