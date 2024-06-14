using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugadorController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float velocidad;
    private int contador;
    public Text TextoContador, TextoGanar;



    void Start()
    {
        rb = GetComponent<Rigidbody>();

        contador = 0;

        setTextoContador();

        TextoGanar.text="";


    }
    void Update () {


         float movimientoH = Input.GetAxis("Horizontal");
         float movimientoV = Input.GetAxis("Vertical");

         Vector3 movimiento = new Vector3(movimientoH, 0.0f,movimientoV);

         rb.AddForce(movimiento * velocidad);
}

void OnTriggerEnter(Collider other)
 {
 if (other.gameObject.CompareTag ("coleccionable"))
 {
 other.gameObject.SetActive (false);
 contador = contador + 1;

 setTextoContador();
 }
 }

 void setTextoContador(){
TextoContador.text = "Contador: " + contador.ToString();
if (contador >= 12){
TextoGanar.text = "¡Ganaste!";
}
}


    
    
}
