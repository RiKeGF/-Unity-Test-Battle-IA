using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
   public Scripts scScripts;

   public bool estaNoChao;

   // Start is called before the first frame update
   void Start()
   {
      scScripts = GameObject.FindGameObjectWithTag("Scripts").GetComponent<Scripts>();


      this.transform.SetParent(scScripts.scSpawnColetavel.fixColetavel.transform);

   }

   // Update is called once per frame
   void Update()
   {
      verificarChao();
   }


   public void verificarChao()
   {

      if (scScripts.scGerenciar.scColetorTM1.carregandoColetavel || scScripts.scGerenciar.scColetorTM2.carregandoColetavel)
      {
         estaNoChao = false;
      }
      else
      {
         estaNoChao = true;
    
      }
   }


   private void OnTriggerStay(Collider col)
   {
      if (col.tag == "Area")
      {
         scScripts.scSpawnColetavel.estaNaArea = true;
      }
      else if (col.tag == "Altar")
      {
         scScripts.scSpawnColetavel.estaNaArea = false;
      }
   }
}
