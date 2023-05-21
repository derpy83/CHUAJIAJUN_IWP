using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHP : MonoBehaviour
{
    public Animator animator;
    public Slider Healthbar;
    public int MaxHP;
    
    // Start is called before the first frame update
    void Start()
    {
        Healthbar.value = MaxHP;
    }

    // Update is called once per frame
    
    public void takeDmg(int Damage)
    {
        Healthbar.value -= Damage;

        //Hurt Animation
        animator.SetTrigger("Hurt");

        if(Healthbar.value <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Boss Died!!!");
        //Die Animation
        animator.SetBool("IsDead", true);
        //Destory Boss
        
        //GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
