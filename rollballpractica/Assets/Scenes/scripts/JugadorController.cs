using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JugadorController : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidad;
    private int contador;
    public Text TextoContador, TextoGanar, TextoTimer, TextoFin;
    public float tiempoRestante = 60f;
    private bool nivelCompleto = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        setTextoContador();
        TextoGanar.text = "";
        TextoTimer.text = "Tiempo: " + tiempoRestante.ToString("F2");
        TextoFin.text = ""; // Inicializa el texto de fin como vacío
        StartCoroutine(Timer());
    }

    void Update()
    {
        if (!nivelCompleto)
        {
            float movimientoH = Input.GetAxis("Horizontal");
            float movimientoV = Input.GetAxis("Vertical");
            Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);
            rb.AddForce(movimiento * velocidad);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coleccionable"))
        {
            other.gameObject.SetActive(false);
            contador++;
            setTextoContador();
        }
    }

    void setTextoContador()
    {
        TextoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12)
        {
            TextoGanar.text = "¡Ganaste!";
            nivelCompleto = true;
            StartCoroutine(MostrarMensajeYRetornarAlMenu("¡Ganaste! Volviendo al menú principal dentro de 5 segundos"));
        }
    }

    IEnumerator Timer()
    {
        while (tiempoRestante > 0 && !nivelCompleto)
        {
            yield return new WaitForSeconds(1f);
            tiempoRestante -= 1f;
            TextoTimer.text = "Tiempo: " + tiempoRestante.ToString("F2");
        }

        if (!nivelCompleto)
        {
            TextoGanar.text = "¡Perdiste!";
            nivelCompleto = true;
            StartCoroutine(MostrarMensajeYRetornarAlMenu("¡Perdiste! Volviendo al menú principal dentro de 5 segundos"));
        }
    }

    IEnumerator MostrarMensajeYRetornarAlMenu(string mensaje)
    {
        TextoFin.text = mensaje; 
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
