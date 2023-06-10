using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float speed;
    public float timer;

    public Transform Attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDmg = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector2 direction = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(direction.x, direction.y);

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot - 72);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpellAtk();
    }

    void SpellAtk()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Attackpoint.position, attackrange, enemyLayers);

        foreach (Collider2D hero in hitEnemies)
        {
            Debug.Log("Player got hit");
            hero.GetComponent<Player_Health>().takeDmg(attackDmg);
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
