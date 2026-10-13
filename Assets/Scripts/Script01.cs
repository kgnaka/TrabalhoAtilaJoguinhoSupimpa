using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Script01 : MonoBehaviour
{
    public float velocidade = 10f;
    private Rigidbody2D rb;
    private Vector2 entradaMovimento;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moverX = Input.GetAxisRaw("Horizontal");
        float moverY = Input.GetAxisRaw("Vertical");

        entradaMovimento = new Vector2(moverX, moverY).normalized;

    }

    void FixedUpdate()
    {
        // Aplica o movimento no Rigidbody2D de forma constante e fluida
        rb.linearVelocity = entradaMovimento * velocidade;
    }

}
