using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject jugador;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - jugador.transform.position;

    }

    void LateUpdate () {

    transform.position = jugador.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
