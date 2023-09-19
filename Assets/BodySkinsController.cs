using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BodySkinsController : MonoBehaviour
{
    [Header("Специальные скины")]
    [SerializeField] GameObject[] specialHatsArray;
    [SerializeField] GameObject[] specialBodiesArray;
    Dictionary<string, GameObject> specialBodiesDict = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> specialHatsDict = new Dictionary<string, GameObject>();
    [Header ("Стандартный скин")]
    [SerializeField] bool isDefaltBodyChoose;
    [SerializeField] GameObject defaultBody;
    [SerializeField] GameObject defaultShirt;
    [SerializeField] GameObject[] defaultPants;
    [Header("Материалы")]
    [SerializeField] Material[] materialsArray;
    Dictionary<string, Material> colorsDict = new Dictionary<string, Material>();   
    [Header("Контроллеры")]
    [SerializeField] MoneyManager moneyManager;
    void Start()
    {
        
        colorsDict.Add("green", materialsArray[0]);
        colorsDict.Add("blue", materialsArray[1]);
        colorsDict.Add("yellow", materialsArray[2]);
        colorsDict.Add("pink", materialsArray[3]);
        colorsDict.Add("purple", materialsArray[4]);
        colorsDict.Add("orange", materialsArray[5]);
        colorsDict.Add("red", materialsArray[6]);
        colorsDict.Add("silver", materialsArray[7]);
        colorsDict.Add("gold", materialsArray[8]);

        specialBodiesDict.Add("doge", specialBodiesArray[0]);
        specialBodiesDict.Add("bomb", specialBodiesArray[1]);
        specialBodiesDict.Add("hair", specialBodiesArray[2]);
        specialBodiesDict.Add("cape", specialBodiesArray[3]);
        specialBodiesDict.Add("pig", specialBodiesArray[4]);
        specialBodiesDict.Add("spider", specialBodiesArray[5]);

        specialHatsDict.Add("doge", specialBodiesArray[0]);
        specialHatsDict.Add("bomb", specialBodiesArray[1]);
        specialHatsDict.Add("hair", specialBodiesArray[2]);
        specialHatsDict.Add("cape", specialBodiesArray[3]);
        specialHatsDict.Add("pig", specialBodiesArray[4]);
        specialHatsDict.Add("spider", specialBodiesArray[5]);
    }


    public void ChangeSpecialSkin(string skinName)
    {
        defaultBody.SetActive(false);
        ResetSkins();
        specialBodiesDict[skinName].SetActive(true);
        specialHatsDict[skinName].SetActive(true);
    }
    public void ChangeShirtColor(string color)
    {
        ResetSkins();
        defaultBody.SetActive(true);
        defaultShirt.GetComponent<SkinnedMeshRenderer>().material = colorsDict[color];       
    }
    public void ChangePantsColor(string color)
    {
        ResetSkins();
        defaultBody.SetActive(true);      
        foreach(var pant in defaultPants)
        {
            pant.GetComponent<SkinnedMeshRenderer>().material = colorsDict[color];
        }
    }
    void ResetSkins()
    {
        foreach (var item in specialHatsArray) 
        { 
            item.SetActive(false);
        }
        foreach (var item in specialBodiesArray)
        {
            item.SetActive(false);
        }
    }
}
