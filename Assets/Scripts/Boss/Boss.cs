using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public Transform Attackpoint;

    public bool isFlipped = false;

    private Animator enemyAnim;
    public void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
            Attackpoint.transform.localPosition = new Vector3(-0.144f, -0.197f, 1);
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
            Attackpoint.transform.localPosition = new Vector3(-0.152f, -0.197f, 1);
        }
    }

    public void randomStatePicker()
    {
        int randomstate = Random.Range(0, 2);
        if (randomstate == 0)
        {
            //AtkDown Animation
            enemyAnim.SetTrigger("Walk");
        }
        else if (randomstate == 1)
        {
            //SpellCasting Animation
            enemyAnim.SetTrigger("Casting");
        }
    }
}
