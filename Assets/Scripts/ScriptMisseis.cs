using UnityEngine;

// Fica no prefab do missil. So cuida do proprio missil:
// ele cai com a gravidade do Rigidbody2D e some quando bate no chao.
// Quem morre ao ser atingido e o gato (ver Script01).
public class ScriptMisseis : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao") || collision.gameObject.CompareTag("Gato"))
        {
            Destroy(gameObject); //missil explode ao tocar no chao ou no gato
        }
    }
}
