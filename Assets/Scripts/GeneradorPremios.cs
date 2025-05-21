using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPremios : MonoBehaviour
{
    public GameObject cuboPrefab;
    public Transform[] otrasPosiciones;

    private void Start()
    {
        InvokeRepeating("GenerarPremios", 0f, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Jugador")
        {
            
        }
    }

    public void GenerarPremios()
    {
        int randomIndex = Random.Range(0, otrasPosiciones.Length);
        Instantiate(cuboPrefab, otrasPosiciones[randomIndex].position, Quaternion.identity);
    }
}
