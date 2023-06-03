using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public PooledObject[] objects;

    public static ObjectPooling Instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (!Instance)
            Instance = this;

        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            int size = objects[i].poolSize;

            for (int j = 0; j < size; j++)
            {
                GameObject temp = Instantiate(objects[i].instance);
                temp.SetActive(false);
                objects[i].pooledObjects.Add(temp);
            }
        }
    }

    public GameObject GetObject(string name)
    {
        PooledObject p = Array.Find<PooledObject>(objects, o => o.name == name);

        foreach (GameObject o in p.pooledObjects)
            if (!o.activeInHierarchy)
                return o;
        
        return null;
    }
}




[Serializable]
public class PooledObject
{
    public string name;
    public GameObject instance;
    public int poolSize;
    public List<GameObject> pooledObjects;
}
