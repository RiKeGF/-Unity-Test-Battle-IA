using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bases : MonoBehaviour
{
   public Scripts scScripts;

   public string ID;



   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }


   private void OnTriggerEnter(Collider col)
   {
      switch (ID)
      {
         case "BaseCTM1":
         {
            if (col.tag == "ColetorTM1")
            {
               GetComponent<MeshRenderer>().material = scScripts.scMaterials.verde;
               scScripts.scGerenciar.scColetorTM1.estaNaBase = true;


            }
            else if (col.tag == "Coletavel")
            {

               scScripts.scHUD.pontosTM1++;
               scScripts.scSpawnColetavel.instanceColetavel.transform.position = scScripts.scSpawnColetavel.localColetavel.transform.position;
               scScripts.scSpawnColetavel.instanceColetavel.transform.SetParent(scScripts.scSpawnColetavel.fixColetavel.transform);
               scScripts.scSpawnColetavel.respawn = true;

            }
            break;
         }
         case "BaseCTM2":
         {
            if (col.tag == "ColetorTM2")
            {
               GetComponent<MeshRenderer>().material = scScripts.scMaterials.verde;
               scScripts.scGerenciar.scColetorTM2.estaNaBase = true;
            }
            else if (col.tag == "Coletavel")
            {

               scScripts.scHUD.pontosTM2++;
               scScripts.scSpawnColetavel.instanceColetavel.transform.position = scScripts.scSpawnColetavel.localColetavel.transform.position;
               scScripts.scSpawnColetavel.instanceColetavel.transform.SetParent(scScripts.scSpawnColetavel.fixColetavel.transform);
               scScripts.scSpawnColetavel.respawn = true;

            }
            break;
         }
         case "BaseATM1":
         {
            if (col.tag == "AtacanteTM1")
            {
               GetComponent<MeshRenderer>().material = scScripts.scMaterials.verde;
               scScripts.scGerenciar.scAtacanteTM1.estaNaBase = true;
            }
            break;
         }
         case "BaseATM2":
         {
            if (col.tag == "AtacanteTM2")
            {
               GetComponent<MeshRenderer>().material = scScripts.scMaterials.verde;
               scScripts.scGerenciar.scAtacanteTM2.estaNaBase = true;
            }
            break;
         }
      }

   }
   private void OnTriggerExit(Collider col)
   {
      switch (ID)
      {
         case "BaseCTM1":
         {
            if (col.tag == "ColetorTM1")
            {
               GetComponent<MeshRenderer>().material = scScripts.scMaterials.vermelho;
               scScripts.scGerenciar.scColetorTM1.estaNaBase = false;
            }
            break;
         }
         case "BaseCTM2":
         {
            if (col.tag == "ColetorTM2")
            {
               GetComponent<MeshRenderer>().material = scScripts.scMaterials.vermelho;
               scScripts.scGerenciar.scColetorTM2.estaNaBase = false;
            }
            break;
         }
         case "BaseATM1":
         {
            if (col.tag == "AtacanteTM1")
            {
               GetComponent<MeshRenderer>().material = scScripts.scMaterials.vermelho;
               scScripts.scGerenciar.scAtacanteTM1.estaNaBase = false;
            }
            break;
         }
         case "BaseATM2":
         {
            if (col.tag == "AtacanteTM2")
            {
               GetComponent<MeshRenderer>().material = scScripts.scMaterials.vermelho;
               scScripts.scGerenciar.scAtacanteTM2.estaNaBase = false;
            }
            break;
         }
      }
   }
}
