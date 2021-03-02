using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ColetorTM1 : MonoBehaviour
{
   public Scripts scScripts;

   public bool morreu;
   public bool retornar;
   public bool coletar;
   public bool estaNaArea;
   public bool carregandoColetavel;
   public bool estaNaBase;

   public GameObject baseCTM1;

   public GameObject alvo;
   public GameObject portao;

   private void Update()
   {
      verificarCarregamento();

      controles();

      if (scScripts.scSpawnColetavel.estaNaArea)
      {
         if (alvo.gameObject != null && !scScripts.scSpawnColetavel.waiting)
         {
            percorrerCaminho();
         }
      }
     
     
   }


   public void controles()
   {

   }

   public void percorrerCaminho() {

      switch (alvo.tag)
      {
         case "Base":
         {
            float step = 3 * Time.deltaTime;
            if (transform.position != alvo.transform.position)
            {
               transform.position = Vector3.MoveTowards(transform.position, new Vector3(alvo.transform.position.x, alvo.transform.position.y + 1.35f, alvo.transform.position.z), step);
            }
            

            break;
         }
         case "Coletavel":
         {
            float step = 3 * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, step);
            break;
         }
         case "Portao":
         {
            float step = 3 * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, step);
            break;
         }
      }
   }
   

   public void verificarCarregamento()
   {
      Transform obj = GetComponentInChildren<Transform>();
      foreach (Transform child in obj)
      {
         if (child.CompareTag("Coletavel"))
         {
            carregandoColetavel = true;
         }
         else
         {
            carregandoColetavel = false;
         }
      }
   }

   private void OnTriggerEnter(Collider col)
   {
      if (col.tag == "Coletavel")
      {
         scScripts.scSpawnColetavel.instanceColetavel.transform.SetParent(this.transform);
         alvo = portao;

      }
      else if (col.tag == "Portao")
      {
         if (carregandoColetavel)
         {
            alvo = baseCTM1;
         }
         else
         {
            alvo = scScripts.scSpawnColetavel.instanceColetavel.gameObject;
         }

      }
      else if (col.tag == "Base")
      {
         scScripts.scSpawnColetavel.respawn = true;
      }
      else if (col.tag == "Limite")
      {

         StartCoroutine(respawn());
      }
   }

   private void OnTriggerStay(Collider col)
   {
      if (col.tag == "Area")
      {
         estaNaArea = true;
      }
   }

   private void OnTriggerExit(Collider col)
   {
      if (col.tag == "Area")
      {
         estaNaArea = false;
      }
   }

   IEnumerator respawn()
   {
      yield return new WaitForSeconds(2);
      this.transform.position = new Vector3(baseCTM1.transform.position.x, baseCTM1.transform.position.y + 1, baseCTM1.transform.position.z);
   }
}
