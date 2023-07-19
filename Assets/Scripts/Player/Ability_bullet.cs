using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_bullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;

    public Transform Attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemyLayers;
    public LayerMask bossLayers;
    public int attackDmg = 5;

    
    public void Shoot(Vector3 shootdir)
    {
        rb.velocity = shootdir * speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AbilityAtk();
    }

    void AbilityAtk()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Attackpoint.position, attackrange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit");

            enemy.GetComponent<enemyHP>().takeDmg(attackDmg);
            Destroy(gameObject);
        }
        Collider2D[] hitboss = Physics2D.OverlapCircleAll(Attackpoint.position, attackrange, bossLayers);
        foreach (Collider2D enemy in hitboss)
        {
            Debug.Log("Hit");

            enemy.GetComponent<BossHP>().takeDmg(attackDmg);
            Destroy(gameObject);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (Attackpoint == null)
            return;
        Gizmos.DrawWireSphere(Attackpoint.position, attackrange);
    }
}
