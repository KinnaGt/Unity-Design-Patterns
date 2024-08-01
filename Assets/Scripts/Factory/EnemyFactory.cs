using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyFactory
{
    public enum EnemyType
    {
        Red,
        Purple
    }

    public static Enemy CreateEnemy(EnemyType type, Sprite sprite)
    {
        GameObject enemyObject = new GameObject();
        enemyObject.AddComponent<SpriteRenderer>().sprite = sprite;
        Enemy enemy = null;

        switch (type)
        {
            case EnemyType.Red:
                enemy = enemyObject.AddComponent<Red>();
                enemyObject.name = "Red";
                break;
            case EnemyType.Purple:
                enemy = enemyObject.AddComponent<Purple>();
                enemyObject.name = "Purple";
                break;
        }

        return enemy;
    }
}
