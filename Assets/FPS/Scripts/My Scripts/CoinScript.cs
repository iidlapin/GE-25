using UnityEngine;
using UnityEngine.Events;
public class CoinScript : MonoBehaviour
{
    public UnityEvent coinCollect;


    private void Start()
    {
        coinCollect.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().IncrementScore);
        coinCollect.AddListener(GameObject.FindGameObjectWithTag("UIController").GetComponent<UiController>().UpdateScore);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            coinCollect.Invoke();
            Destroy(gameObject);
        }
    } 
}
