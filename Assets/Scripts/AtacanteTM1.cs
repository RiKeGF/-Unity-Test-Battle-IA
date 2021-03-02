using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AtacanteTM1 : MonoBehaviour
{
   public Scripts scScripts;

   public bool retornar;
   public bool atacar;
   public bool estaNaArea;
   public bool estaNaBase;
   public bool estaNoPortao;

   public GameObject baseATM1;

   public GameObject alvo;
   public GameObject portao;
   private void Update()
   {
      if (scScripts.scGerenciar.scColetorTM2.estaNaArea)
      {
         atacar = true;
         retornar = false;

      }
      else
      {
         atacar = false;
         retornar = true;

      }


      if (atacar && !scScripts.scSpawnColetavel.waiting)
      {
         if (estaNaBase)
         {
            alvo = portao;
         }
         if (estaNoPortao && !scScripts.scSpawnColetavel.waiting)
         {
            alvo = scScripts.scGerenciar.scColetorTM2.gameObject;
         }


      }
      else if (retornar)
      {
         if (!estaNaBase && alvo.tag != "Base")
         {
            alvo = portao;
         }
         if (estaNoPortao)
         {
            alvo = baseATM1;
         }

      }



      percorrerCaminho();
   }

   public void percorrerCaminho()
   {
      if (atacar)
      {
         switch (alvo.tag)
         {
            case "ColetorTM2":
            {
               float step = 5 * Time.deltaTime;
               if (transform.position.x != alvo.transform.position.x)
               {
                  transform.position = Vector3.MoveTowards(transform.position, new Vector3(alvo.transform.position.x, alvo.transform.position.y, alvo.transform.position.z), step);
               }
               break;
            }
            case "Portao":
            {
               float step = 3 * Time.deltaTime;

               if (transform.position.x != alvo.transform.position.x)
               {
                  transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, step);
               }


               break;
            }
         }
      }

      if (retornar)
      {
         switch (alvo.tag)
         {
            case "Base":
            {
               float step = 5 * Time.deltaTime;
               if (transform.position.x != alvo.transform.position.x)
               {
                  transform.position = Vector3.MoveTowards(transform.position, new Vector3(alvo.transform.position.x, alvo.transform.position.y + 1.35f, alvo.transform.position.z), step);
               }
               break;
            }
            case "Portao":
            {
               float step = 3 * Time.deltaTime;
               if (transform.position.x != alvo.transform.position.x)
               {
                  transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, step);
               }

               break;
            }
         }
      }

   }

   private void OnTriggerEnter(Collider col)
   {
      if (col.tag == "Portao")
      {
         estaNoPortao = true;
      }
      else if (col.tag == "ColetorTM2")
      {
         Vector3 force = col.gameObject.transform.forward * 1000;
         col.GetComponent<Rigidbody>().AddForce(force);

      }
      else if (col.tag == "Limite")
      {
         this.transform.position = new Vector3(baseATM1.transform.position.x, baseATM1.transform.position.y+1, baseATM1.transform.position.z);
      }
   }

   private void OnTriggerStay(Collider col)
   {
      if (col.tag == "Portao")
      {
         estaNoPortao = true;
      }
   }
   private void OnTriggerExit(Collider col)
   {
      if (col.tag == "Portao")
      {
         estaNoPortao = false;
      }
   }
}