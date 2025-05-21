using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public TextMeshProUGUI txtPuntos;
    public Camera cam;

    public GameObject panelYouWin;
    float score;
    public float meta = 100; 

    float penalizacion = 5;
    float aumento = 5;

    bool finJuego = false;

    void Start()
    {
        txtPuntos.text = "0";
        panelYouWin.SetActive(false);
    }

    private void Update()
    {
        score += Time.deltaTime;
        txtPuntos.text = Mathf.RoundToInt(score).ToString();

        if((score >= meta) && !finJuego)
        {
            print("ganó");
            panelYouWin.SetActive(true);
            finJuego = true;
        }
    }

    void FixedUpdate()
    {
        if(!finJuego)
        {
            float movimientoHorizontal = Input.GetAxis("Horizontal") * 5;
            rb.velocity = new Vector3(movimientoHorizontal, rb.velocity.y, rb.velocity.z);

            GetComponent<Animator>().SetBool("run", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("run", false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Obstaculo"))
        {
            score -= penalizacion;
            cam.backgroundColor = Color.red;
            //GetComponent<Animator>().Play("Chocar");
            Destroy(other.gameObject);
            StartCoroutine(CambiarColorCamara());
        }
        else if (other.name.Contains("Premio"))
        {
            score += aumento;
            Destroy(other.gameObject);
        }
    }

    public IEnumerator CambiarColorCamara()
    {
        yield return new WaitForSeconds(0.5f);
        Color colorRGB = new Color(0.8f, 0.9f, 0.8f);
        cam.backgroundColor = colorRGB;
    }
}
