using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Abilities : MonoBehaviour
{
    public GameObject Ability_1;
    public GameObject Ability_2;
    public GameObject Ability_3;

    public GameObject A1_Bullet;
    public GameObject A2_Bullet;
    public GameObject A3_Bullet;

    public Transform point;

    HeroKnight player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<HeroKnight>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Ability_1.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ability1();
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
}
