using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHP : MonoBehaviour
{
    public Animator animator;
    public int currentHp;
    public int MaxHP;
    public float deathDelay = 2.5f;

    public bool isInvuknerable = false;

    public static enemyHP Instance;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = MaxHP;
        Instance = this;
    }

    // Update is called once per frame
    
    public void takeDmg(int Damage)
    {
        if (isInvuknerable == true)
            return;

        currentHp -= Damage;
        

        
        if(currentHp <= 0)
        {
            animator.SetTrigger("Dead");
            animator.SetBool("IsDead", true);
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + deathDelay);
        }
    }
    
}
