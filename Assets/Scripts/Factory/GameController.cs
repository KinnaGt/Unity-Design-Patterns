using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Sprite redSprite;

    [SerializeField]
    Sprite purpleSprite;

    void Start()
    {
        Enemy red = EnemyFactory.CreateEnemy(EnemyFactory.EnemyType.Red,redSprite);
        red.transform.position = new Vector3(0, 0, 0);
        red.Attack();

        Enemy purple = EnemyFactory.CreateEnemy(EnemyFactory.EnemyType.Purple,purpleSprite);
        purple.transform.position = new Vector3(2, 0, 0);
        purple.Attack();
    }
}
