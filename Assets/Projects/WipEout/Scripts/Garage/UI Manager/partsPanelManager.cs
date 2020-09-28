using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class partsPanelManager : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject partsPrefab;
    public GameObject partsParent;
    [Space]
    public AllFramePartsOwned allFramePartsOwned;
    public AllEnginePartsOwned allEnginePartsOwned;
    public AllThrusterPartsOwned allThrusterPartsOwned;
    public AllSteeringFinPartsOwned allSteeringFinPartsOwned;
    public AllControlSystemPartsOwned allControlSystemPartsOwned;
    public AllWeaponSystemPartsOwned allWeaponSystemPartsOwned;
    [Space]
    public overviewManager overviewManager;
    public SystemManager systemManager;
    [Space]
    public Vector3 partPosStartingPoint;
    public Vector3 partPosOffset;

    public void enableMainPanel ()
    {
        MainPanel.SetActive(true);
    }
    public void disableMainPanel ()
    {
        MainPanel.SetActive(false);
    }

    public void onClickEquipedFramePart ()
    {
        onClickInventoryPart();
        enableMainPanel();
        for (int i = 0; i < allFramePartsOwned.partsOwned.Count; i++)
        {
            Vector3 Pos = partPosStartingPoint;
            Pos.x += partPosOffset.x * i;
            GameObject g = Instantiate( partsPrefab, Pos, Quaternion.identity);

            g.transform.SetParent(partsParent.transform, false);

            g.GetComponent<partsPanel>().framePart = allFramePartsOwned.partsOwned[i];
            g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allFramePartsOwned.partsOwned[i].weight.ToString();
            g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allFramePartsOwned.partsOwned[i].powerNeeded.ToString();

            g.GetComponent<partsPanel>().overviewManager = overviewManager;

            g.GetComponent<partsPanel>().button = g.transform.GetChild(5).gameObject.GetComponent<Button>();
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => overviewManager.NewFramePart(g.GetComponent<partsPanel>().framePart));
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => onClickInventoryPart());
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => systemManager.Save());
        }
    }
    public void onClickEquipedEnginePart()
    {
        onClickInventoryPart();
        enableMainPanel();
        for (int i = 0; i < allEnginePartsOwned.partsOwned.Count; i++)
        {
            Vector3 Pos = partPosStartingPoint;
            Pos.x += partPosOffset.x * i;
            GameObject g = Instantiate(partsPrefab, Pos, Quaternion.identity);

            g.transform.SetParent(partsParent.transform, false);

            g.GetComponent<partsPanel>().enginePart = allEnginePartsOwned.partsOwned[i];
            g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allEnginePartsOwned.partsOwned[i].weight.ToString();
            g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allEnginePartsOwned.partsOwned[i].powerNeeded.ToString();

            g.GetComponent<partsPanel>().overviewManager = overviewManager;

            g.GetComponent<partsPanel>().button = g.transform.GetChild(5).gameObject.GetComponent<Button>();
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => overviewManager.NewEnginePart(g.GetComponent<partsPanel>().enginePart));
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => onClickInventoryPart());
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => systemManager.Save());
        }
    }
    public void onClickEquipedThrusterPart()
    {
        onClickInventoryPart();
        enableMainPanel();
        for (int i = 0; i < allThrusterPartsOwned.partsOwned.Count; i++)
        {
            Vector3 Pos = partPosStartingPoint;
            Pos.x += partPosOffset.x * i;
            GameObject g = Instantiate(partsPrefab, Pos, Quaternion.identity);

            g.transform.SetParent(partsParent.transform, false);

            g.GetComponent<partsPanel>().thrusterPart = allThrusterPartsOwned.partsOwned[i];
            g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allThrusterPartsOwned.partsOwned[i].weight.ToString();
            g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allThrusterPartsOwned.partsOwned[i].powerNeeded.ToString();

            g.GetComponent<partsPanel>().overviewManager = overviewManager;

            g.GetComponent<partsPanel>().button = g.transform.GetChild(5).gameObject.GetComponent<Button>();
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => overviewManager.NewThrusterPart(g.GetComponent<partsPanel>().thrusterPart));
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => onClickInventoryPart());
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => systemManager.Save());
        }
    }
    public void onClickEquipedSteeringFinPart()
    {
        onClickInventoryPart();
        enableMainPanel();
        for (int i = 0; i < allSteeringFinPartsOwned.partsOwned.Count; i++)
        {
            Vector3 Pos = partPosStartingPoint;
            Pos.x += partPosOffset.x * i;
            GameObject g = Instantiate(partsPrefab, Pos, Quaternion.identity);

            g.transform.SetParent(partsParent.transform, false);

            g.GetComponent<partsPanel>().steeringFinPart = allSteeringFinPartsOwned.partsOwned[i];
            g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allSteeringFinPartsOwned.partsOwned[i].weight.ToString();
            g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allSteeringFinPartsOwned.partsOwned[i].powerNeeded.ToString();

            g.GetComponent<partsPanel>().overviewManager = overviewManager;

            g.GetComponent<partsPanel>().button = g.transform.GetChild(5).gameObject.GetComponent<Button>();
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => overviewManager.NewSteeringFinPart(g.GetComponent<partsPanel>().steeringFinPart));
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => onClickInventoryPart());
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => systemManager.Save());
        }
    }
    public void onClickEquipedControlSystemPart()
    {
        onClickInventoryPart();
        enableMainPanel();
        for (int i = 0; i < allControlSystemPartsOwned.partsOwned.Count; i++)
        {
            Vector3 Pos = partPosStartingPoint;
            Pos.x += partPosOffset.x * i;
            GameObject g = Instantiate(partsPrefab, Pos, Quaternion.identity);

            g.transform.SetParent(partsParent.transform, false);

            g.GetComponent<partsPanel>().controlSystemPart = allControlSystemPartsOwned.partsOwned[i];
            g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allControlSystemPartsOwned.partsOwned[i].weight.ToString();
            g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allControlSystemPartsOwned.partsOwned[i].powerNeeded.ToString();

            g.GetComponent<partsPanel>().overviewManager = overviewManager;

            g.GetComponent<partsPanel>().button = g.transform.GetChild(5).gameObject.GetComponent<Button>();
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => overviewManager.NewControlSystemPart(g.GetComponent<partsPanel>().controlSystemPart));
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => onClickInventoryPart());
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => systemManager.Save());
        }
    }
    public void onClickEquipedWeaponSystemPart()
    {
        onClickInventoryPart();
        enableMainPanel();
        for (int i = 0; i < allWeaponSystemPartsOwned.partsOwned.Count; i++)
        {
            Vector3 Pos = partPosStartingPoint;
            Pos.x += partPosOffset.x * i;
            GameObject g = Instantiate(partsPrefab, Pos, Quaternion.identity);

            g.transform.SetParent(partsParent.transform, false);

            g.GetComponent<partsPanel>().weaponSystemPart = allWeaponSystemPartsOwned.partsOwned[i];
            g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allWeaponSystemPartsOwned.partsOwned[i].weight.ToString();
            g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allWeaponSystemPartsOwned.partsOwned[i].powerNeeded.ToString();

            g.GetComponent<partsPanel>().overviewManager = overviewManager;

            g.GetComponent<partsPanel>().button = g.transform.GetChild(5).gameObject.GetComponent<Button>();
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => overviewManager.NewWeaponSystemPart(g.GetComponent<partsPanel>().weaponSystemPart));
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => onClickInventoryPart());
            g.GetComponent<partsPanel>().button.onClick.AddListener(() => systemManager.Save());
        }
    }

    public void onClickInventoryPart ()
    {
        foreach (Transform child in partsParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        disableMainPanel();
    }
}
