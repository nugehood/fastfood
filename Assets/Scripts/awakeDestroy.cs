using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awakeDestroy : MonoBehaviour
{
    public GameObject[] destroyedGameObject;
    public float destroyTime;
    private void Awake()
    {
        for(int i = 0;i < destroyedGameObject.Length; i++)
        {
            Destroy(destroyedGameObject[i]);
            Destroy(gameObject,destroyTime);
        }
    }
}
