using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSide : MonoBehaviour
{
    public int side = 0;
    
    void OnTriggerStay(Collider other) { 
        side = int.Parse(other.gameObject.name);
    }
}
