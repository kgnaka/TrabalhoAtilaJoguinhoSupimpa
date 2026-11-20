using UnityEngine;

// Fica num objeto vazio da cena ("SpawnerMisseis").
// Espera a bola sumir e depois cria um missil a cada "intervalo" segundos,
// numa posicao X aleatoria no alto da tela.
public class ScriptSpawnMisseis : MonoBehaviour
{
    public GameObject missil; //prefab MissilBalisticoIntercontinentalObj
    public float intervalo = 3f; //segundos entre um missil e outro
    public float minX = -10f; //borda esquerda
    public float maxX = 10f; //borda direita
    public float alturaSpawn = 3.3f; //o missil inteiro tem que nascer abaixo da Borda Superior (y ~4.85), senao fica preso nela

    private bool bolaSumiu = false;
    private float tempoDesdeUltimo = 0f;

    void Update()
    {
        if (GameObject.FindWithTag("Gato") == null) return; //gato morreu, para de mandar missil

        if (!bolaSumiu)
        {
            if (GameObject.FindWithTag("Bola") != null) return; //bola ainda existe, espera

            bolaSumiu = true;
            tempoDesdeUltimo = intervalo; //primeiro missil sai na hora que a bola some
        }

        tempoDesdeUltimo += Time.deltaTime;

        if (tempoDesdeUltimo >= intervalo)
        {
            tempoDesdeUltimo = 0f;
            SpawnMissil();
        }
    }

    void SpawnMissil()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 posicao = new Vector3(randomX, alturaSpawn, 0f);

        Instantiate(missil, posicao, missil.transform.rotation); //mantem a rotacao do prefab (bico pra baixo)
    }
}
