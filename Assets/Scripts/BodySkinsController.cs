using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BodySkinsController : MonoBehaviour
{
    [Header("Специальные скины")]
    [SerializeField] GameObject[] standSpecialHatsArray;
    [SerializeField] GameObject[] standSpecialBodiesArray;
    [SerializeField] GameObject[] characterSpecialHatsArray;
    [SerializeField] GameObject[] characterSpecialBodiesArray;  
    Dictionary<string, GameObject> standSpecialBodiesDict = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> standSpecialHatsDict = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> characterSpecialBodiesDict = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> characterSpecialHatsDict = new Dictionary<string, GameObject>();
    [Header ("Манекен")]
    [SerializeField] GameObject defaultStandBody;
    [SerializeField] GameObject defaultStandShirt;
    [SerializeField] GameObject[] defaultStandPants;
    [Header("Персонаж")]
    [SerializeField] GameObject defaultCharacterBody;
    [SerializeField] GameObject defaultCharacterShirt;
    [SerializeField] GameObject[] defaultCharacterPants;
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
        //Заполнеие словарей для манекена
        standSpecialBodiesDict.Add("doge", standSpecialBodiesArray[0]);
        standSpecialBodiesDict.Add("bomb", standSpecialBodiesArray[1]);
        standSpecialBodiesDict.Add("hair", standSpecialBodiesArray[2]);
        standSpecialBodiesDict.Add("cape", standSpecialBodiesArray[3]);
        standSpecialBodiesDict.Add("pig", standSpecialBodiesArray[4]);
        standSpecialBodiesDict.Add("spider", standSpecialBodiesArray[5]);
        standSpecialBodiesDict.Add("indian", standSpecialBodiesArray[6]);

        standSpecialHatsDict.Add("doge", standSpecialHatsArray[0]);
        standSpecialHatsDict.Add("bomb", standSpecialHatsArray[1]);
        standSpecialHatsDict.Add("hair", standSpecialHatsArray[2]);
        standSpecialHatsDict.Add("cape", standSpecialHatsArray[3]);
        standSpecialHatsDict.Add("pig", standSpecialHatsArray[4]);
        standSpecialHatsDict.Add("spider", standSpecialHatsArray[5]);
        standSpecialHatsDict.Add("indian", standSpecialBodiesArray[6]);
        //Заполнение словарей для персонажа
        characterSpecialBodiesDict.Add("doge", characterSpecialBodiesArray[0]);
        characterSpecialBodiesDict.Add("bomb", characterSpecialBodiesArray[1]);
        characterSpecialBodiesDict.Add("hair", characterSpecialBodiesArray[2]);
        characterSpecialBodiesDict.Add("cape", characterSpecialBodiesArray[3]);
        characterSpecialBodiesDict.Add("pig", characterSpecialBodiesArray[4]);
        characterSpecialBodiesDict.Add("spider", characterSpecialBodiesArray[5]);
        characterSpecialBodiesDict.Add("indian", standSpecialBodiesArray[6]);

        characterSpecialHatsDict.Add("doge", characterSpecialHatsArray[0]);
        characterSpecialHatsDict.Add("bomb", characterSpecialHatsArray[1]);
        characterSpecialHatsDict.Add("hair", characterSpecialHatsArray[2]);
        characterSpecialHatsDict.Add("cape", characterSpecialHatsArray[3]);
        characterSpecialHatsDict.Add("pig", characterSpecialHatsArray[4]);
        characterSpecialHatsDict.Add("spider", characterSpecialHatsArray[5]);
        characterSpecialHatsDict.Add("indian", standSpecialBodiesArray[6]);
    }


    public void ChangeSpecialSkin(string skinName)
    {
        defaultCharacterBody.SetActive(false);
        defaultStandBody.SetActive(false);
        ResetSkins();     

        standSpecialBodiesDict[skinName].SetActive(true);
        standSpecialHatsDict[skinName].SetActive(true);
        characterSpecialHatsDict[skinName].SetActive(true);
        characterSpecialBodiesDict[skinName].SetActive(true);
    }
    public void ChangeShirtColor(string color)
    {
        ResetSkins();
        defaultStandBody.SetActive(true);
        defaultCharacterBody.SetActive(true);

        defaultStandShirt.GetComponent<SkinnedMeshRenderer>().material = colorsDict[color];
        defaultCharacterShirt.GetComponent<SkinnedMeshRenderer>().material = colorsDict[color];       
    }
    public void ChangePantsColor(string color)
    {
        ResetSkins();
        defaultStandBody.SetActive(true);
        defaultCharacterBody.SetActive(true);
        foreach (var pant in defaultStandPants)
        {
            pant.GetComponent<SkinnedMeshRenderer>().material = colorsDict[color];
        }
        foreach (var pant in defaultCharacterPants)
        {
            pant.GetComponent<SkinnedMeshRenderer>().material = colorsDict[color];
        }
    }
    void ResetSkins()
    {
        foreach (var item in standSpecialHatsArray) 
        { 
            item.SetActive(false);
        }
        foreach (var item in standSpecialBodiesArray)
        {
            item.SetActive(false);
        }

        foreach (var item in characterSpecialHatsArray)
        {
            item.SetActive(false);
        }
        foreach (var item in characterSpecialBodiesArray)
        {
            item.SetActive(false);
        }
    }
}
