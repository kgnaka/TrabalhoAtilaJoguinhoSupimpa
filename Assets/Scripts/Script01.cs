using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using TMPro; //utiliza os recursos da biblioteca TMPro (texto)


public class Script01 : MonoBehaviour
{
    public float velocidade = 15;
    public float alturaPulo = 17;
    private Rigidbody2D rb; //variavel tipo RigidBody2D para receber as propriedaeds RigidBody2D
    private Vector2 entradaMovimento; //cria variavel vetor
    private bool estaNoChao = false; //verifica se o gato esta encostando no chão
    private SpriteRenderer spriteRenderer; //variavel tipo SpriteRenderer para receber as propriedaeds SpriteRenderer
    public TMP_Text texto; //variavel de texto

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        float moverX = 0f;

        if (Keyboard.current != null) //se alguma tecla esta sendo apertada
        {
            //mexer pra direita
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                moverX = 1f;
                spriteRenderer.flipX = true;
            }
            //mexer pra esquerda
            else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                moverX = -1f;
                spriteRenderer.flipX = false;
            }

            if (estaNoChao == true)
            {
                if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame)
                {
                    Pular();
                }

                // mexer pra cima (antes de criar a mecanica de pular)
                //if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) moverY = 1f;
                //mexer pra baixo (antes de eu adicionar gravidade)
                //else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moverY = -1f;
            }

            entradaMovimento = new Vector2(moverX, 0f).normalized;
            // vetor variavel recebe as informações atualizadas do movimento.
            // .normalized serva para não andar mais rapido na diagonal
        }
    }
    void Pular()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, alturaPulo);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(entradaMovimento.x * velocidade, rb.linearVelocity.y); //velocidade recebe vetor multiplicado pela velocidade e valor da altura do pulo
    }

    private void OnCollisionEnter2D(Collision2D collision) //gato colide com chão
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            estaNoChao = true;
        }

        if (collision.gameObject.CompareTag("Bola")) //se o gato encostar na bolinha
        {

            texto.text = "você perdeu >:p";

            Destroy(gameObject); //apoptose
        }
    }

    private void OnCollisionExit2D(Collision2D collision) //gato para de colidir com chão
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            estaNoChao = false;
        }
    }


}
