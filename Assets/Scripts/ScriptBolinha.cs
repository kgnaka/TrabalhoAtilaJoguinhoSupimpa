using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;

public class ScriptBolinha : MonoBehaviour
{
    public GameObject bola;
    public float velocidadeCrescimento = 0.5f;
    public float tempoDecorrido = 0f; //tempo q passou
    public float tInicioCrescimento = 10f; //10 segundos pra começar a crescer
    public float minX = 0.25f;
    public float maxX = 11f;
    public float minY = 1f;
    public float maxY = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        tempoDecorrido += Time.deltaTime; //variavel tempoDecorrido recebe + qunato tmepo passou desde o ultimo frame do jogo, em s


        if (tempoDecorrido > tInicioCrescimento && tempoDecorrido < 25) //para de crescer após 25s
        {
            transform.localScale += new Vector3(velocidadeCrescimento, velocidadeCrescimento, 0f) * Time.deltaTime;
            //transform.localScale sempre é Vector3, independente do jogo ser 2d
            //ele cresce para cima e para os lados na mesma proporção (velocidadeCrescimento)
        }
        
    }
}
