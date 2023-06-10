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
       
    }

    void AbilityAtk()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Attackpoint.position, attackrange, enemyLayers);

        foreach (Collider2D hero in hitEnemies)
        {
            Debug.Log("Player got hit");
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
