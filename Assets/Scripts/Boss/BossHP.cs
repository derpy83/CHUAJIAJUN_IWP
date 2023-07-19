using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHP : MonoBehaviour
{
    public Animator animator;
    public Slider Healthbar;
    public int MaxHP;
    public float deathDelay = 2.5f;

    public bool isInvuknerable = false;

    public static BossHP Instance;

    public GameObject Ability1;

    // Start is called before the first frame update
    void Start()
    {
        Healthbar.value = MaxHP;
        Instance = this;
    }

    // Update is called once per frame
    
    public void takeDmg(int Damage)
    {
        if (isInvuknerable == true)
            return;

        Healthbar.value -= Damage;
        

        if(Healthbar.value <= 100)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if(Healthbar.value <= 0)
        {
            animator.SetTrigger("Dead");
            animator.SetBool("IsDead", true);
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + deathDelay);
            Ability1.SetActive(true);
        }
    }
    
    
}
