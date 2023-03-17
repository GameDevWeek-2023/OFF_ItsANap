using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimationController : MonoBehaviour
{
    private EnemyMonster enemy;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<EnemyMonster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.followPlayer) ;
        anim.SetBool("hunt",true);
    }
}
