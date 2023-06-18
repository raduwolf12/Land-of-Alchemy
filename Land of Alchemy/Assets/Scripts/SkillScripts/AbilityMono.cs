using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMono : MonoBehaviour
{
    public new string name;
    public float cooldownTime;
    public float activeTime;


    public virtual void Activate(GameObject parent) { }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
