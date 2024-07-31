using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager Instance;
    public GameObject arrowPrefab;
    public int poolSize = 10;

    private List<GameObject> arrowPool;

    void Awake()
    {
        Instance = this;
        arrowPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(arrowPrefab);
            obj.SetActive(false);
            arrowPool.Add(obj);
        }
    }

    public GameObject GetArrow()
    {
        foreach (GameObject arrow in arrowPool)
        {
            if (!arrow.activeInHierarchy)
            {
                return arrow;
            }
        }
        // Si no tenemos flechas disponibles, creamos una nueva pero ya redujimos la cantidad de objetos que se crean
        GameObject newArrow = Instantiate(arrowPrefab); 
        newArrow.SetActive(false);
        arrowPool.Add(newArrow);
        return newArrow;
    }
}
