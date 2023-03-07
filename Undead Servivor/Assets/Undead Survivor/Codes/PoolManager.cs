using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리펩들을 보관할 변수
    public GameObject[] prefabs;

    // 풀 담당을 하는 리스트들
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++) {
            pools[i] = new List<GameObject>();
        }
    }

    // 풀링을 위한 함수
    public GameObject Get(int i)
    {
        GameObject select = null;

        foreach (GameObject obj in pools[i]) {
            if (!obj.activeSelf) {
                select = obj;
                select.SetActive(true);
                break;
            }
        }

        if (select == null) {
            select = Instantiate(prefabs[i], transform);
            pools[i].Add(select);
        }


        return select;
    }
}
