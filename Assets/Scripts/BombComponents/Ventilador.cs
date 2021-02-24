using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour
{
    public int rotSpeed;
    
    void Update()
    {
        this.transform.Rotate(Vector3.forward, rotSpeed * Time.deltaTime);
    }
}
