using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Abilities : MonoBehaviour
{
    public Image Ability_1;
    public Image Ability_2;
    public GameObject A1;
    public GameObject A2;

    public GameObject A1_Bullet;

    public float cooldwn1;
    public float cooldwn2;

    bool isCooldown = false;
    bool isCooldown2 = false;

    public Transform point;

    public int HealingAmount;
    HeroKnight player;
    Player_Health playerhp;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<HeroKnight>();
        Ability_1.fillAmount = 0;
        Ability_2.fillAmount = 0;
        playerhp = GetComponent<Player_Health>();
    }

    // Update is called once per frame
    void Update()
    {
       if(A1.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.X)&& isCooldown ==false)
            {
                isCooldown = true;
                Ability_1.fillAmount = 1;
                ability1();
            }

            
        }
       if(A2.activeSelf == true)
        {
            if(Input.GetKeyDown(KeyCode.Z) && isCooldown2 == false)
            {
                isCooldown2 = true;
                Ability_2.fillAmount = 1;
                ability2();
            }
        }
        if (isCooldown)
        {
            Ability_1.fillAmount -= 1 / cooldwn1 * Time.deltaTime;

            if (Ability_1.fillAmount <= 0)
            {
                Ability_1.fillAmount = 0;
                isCooldown = false;
            }
        }
        if (isCooldown2)
        {
            Ability_2.fillAmount -= 1 / cooldwn2 * Time.deltaTime;

            if (Ability_2.fillAmount <= 0)
            {
                Ability_2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }

    public void ability1()
    {
        GameObject go = Instantiate(A1_Bullet, point.position, point.transform.rotation);
        
        if(player.facingDir > 0)
        {
            go.GetComponent<SpriteRenderer>().flipX = false;
            go.GetComponent<Ability_bullet>().Shoot(transform.right);
        }

        else if(player.facingDir < 0)
        {
            go.GetComponent<SpriteRenderer>().flipX = true;
            go.GetComponent<Ability_bullet>().Shoot(-transform.right);
        }

    }
    public void ability2()
    {
        playerhp.Healthbar.value += HealingAmount;

        if(playerhp.Healthbar.value > playerhp.MaxHP)
        {
            playerhp.Healthbar.value = playerhp.MaxHP;
        }


    }
}
