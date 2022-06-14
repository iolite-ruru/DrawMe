using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public void Awake()
    {
        
        DontDestroyOnLoad(transform.root.gameObject);
    }
}
