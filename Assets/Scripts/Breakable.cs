using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour
{
    public List<GameObject> breabklePieces;
    public float timeToBreak = 2;
    private float timer = 0;
    public UnityEvent OnBreak;
    void Start()
    {
        foreach (var item in breabklePieces)
        {
            item.SetActive(false);
        }
    }

    public void Break()
    {
        timer += Time.deltaTime;

        if (timer > timeToBreak)
        {
            foreach (var item in breabklePieces)
            {
                item.SetActive(true);
                item.transform.parent = null;
            }
            OnBreak.Invoke();
            gameObject.SetActive(false);
        }       
    }
    
}
