using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Health : MonoBehaviour
{
    public Animator animator;
    public Slider Healthbar;
    public int MaxHP;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        Healthbar.value = MaxHP;
        sr = GetComponent<SpriteRenderer>();
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void takeDmg(int Damage)
    {
        Healthbar.value -= Damage;

        //Hurt Animation
        animator.SetTrigger("Hurt");

        StartCoroutine(Invunerability());

        if (Healthbar.value <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Boss Died!!!");
        //Die Animation
        animator.SetBool("isDead", true);
        //Destory Boss

        //GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(3, 7, true);
        sr.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(3, 7, false);
        sr.color = Color.white;
    }
}
