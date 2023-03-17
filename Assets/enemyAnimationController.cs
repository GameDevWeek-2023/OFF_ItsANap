using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimationController : MonoBehaviour
{
    private EnemyMonster enemy;

    private Animator anim;

    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<EnemyMonster>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.followPlayer)
            anim.SetBool("hunt",true);

        if (transform.position.x - player.transform.position.x > 0)
            enemy.transform.localScale = new Vector3(-1, 1, 1);
        else
            enemy.transform.localScale = new Vector3(1, 1, 1);
    }
}
