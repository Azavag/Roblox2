using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardLevelsNavigation : MonoBehaviour
{
     bool isButtonInteractible;
    [SerializeField] Button levelsNavButton;
    [SerializeField] GameObject levelNavMenu;
    [SerializeField] SpawnManager spawnManager;
    [SerializeField] NavigationController navigationController;
    [SerializeField] Transform playerObject;
    [SerializeField] Vector3[] directionsToRotate;
    Dictionary<int, Vector3> directionsDict = new Dictionary<int, Vector3>();
    private void Start()
    {
        directionsDict.Add(5, directionsToRotate[0]);
        directionsDict.Add(10, directionsToRotate[1]);
        directionsDict.Add(16, directionsToRotate[2]);
        directionsDict.Add(20, directionsToRotate[3]);
        directionsDict.Add(25, directionsToRotate[4]);
        directionsDict.Add(30, directionsToRotate[5]);
        directionsDict.Add(36, directionsToRotate[6]);
        directionsDict.Add(41, directionsToRotate[7]);
        directionsDict.Add(45, directionsToRotate[8]);
        directionsDict.Add(51, directionsToRotate[9]);

        SwitchMenuState(false);
        isButtonInteractible = Progress.Instance.playerInfo.isNavButtonActive;
        ActivateLevelsNavButton(isButtonInteractible);
    }

    public void ActivateLevelsNavButton(bool state)
    {
        levelsNavButton.interactable = isButtonInteractible;
    }

    public void SetActiveState(bool state)
    {
        isButtonInteractible = state;
        ActivateLevelsNavButton(isButtonInteractible);
        Progress.Instance.playerInfo.isNavButtonActive = isButtonInteractible;
        YandexSDK.Save();
    }

    public void GoToLevel(int pointNumber)
    {
        spawnManager.UpdatePointNumber(pointNumber - 1);
        spawnManager.RespawnPlayer();
        playerObject.transform.rotation = Quaternion.LookRotation(directionsDict[pointNumber]);
      
        navigationController.ShowPauseMenu();
        levelNavMenu.SetActive(false);
    }


    void SwitchMenuState(bool state)
    {
        levelNavMenu.SetActive(state);
    }
}
