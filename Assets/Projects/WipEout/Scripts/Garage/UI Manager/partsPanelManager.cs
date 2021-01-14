using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class partsPanelManager : MonoBehaviour
{
    /* Description ---
     *    This script should manage the parts panel
     */

    //[SerializeField] private GameObject MainPanel;
    /*[SerializeField] private GameObject partsPrefab;
    [SerializeField] private GameObject partsParent;
    [Space]
    [SerializeField] private AllPartsOwned allPartsOwned;
    [Space]
    [SerializeField] private overviewManager overviewManager;
    [SerializeField] private SystemManager systemManager;
    [Space]
    //[SerializeField] private Vector3 partPosStartingPoint;
    //[SerializeField] private Vector3 partPosOffset;
    private Vector3 Pos;

    public void Awake(){
      Pos = new Vector3(0,0,0);
    }



    public void onClickEquipedFramePart ()
    {
        onClickInventoryPart();
        enableMainPanel();
        for (int i = 0; i < allPartsOwned.framePartsOwned.Count; i++)
        {
            GameObject g = Instantiate( partsPrefab, Pos, Quaternion.identity);

            g.transform.SetParent(partsParent.transform, false);

            g.GetComponent<partsPanel>().framePart = allPartsOwned.framePartsOwned[i];
            g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allPartsOwned.framePartsOwned[i].weight.ToString();
            g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allPartsOwned.framePartsOwned[i].powerNeeded.ToString();

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
        for (int i = 0; i < allPartsOwned.enginePartsOwned.Count; i++)
        {
            GameObject g = Instantiate(partsPrefab, Pos, Quaternion.identity);

            g.transform.SetParent(partsParent.transform, false);

            g.GetComponent<partsPanel>().enginePart = allPartsOwned.enginePartsOwned[i];
            g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allPartsOwned.enginePartsOwned[i].weight.ToString();
            g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allPartsOwned.enginePartsOwned[i].powerNeeded.ToString();

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
        for (int i = 0; i < allPartsOwned.thrusterPartsOwned.Count; i++)
        {

            GameObject g = Instantiate(partsPrefab, Pos, Quaternion.identity);

            g.transform.SetParent(partsParent.transform, false);

            g.GetComponent<partsPanel>().thrusterPart = allPartsOwned.thrusterPartsOwned[i];
            g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allPartsOwned.thrusterPartsOwned[i].weight.ToString();
            g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allPartsOwned.thrusterPartsOwned[i].powerNeeded.ToString();

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
        for (int i = 0; i < allPartsOwned.steeringFinPartsOwned.Count; i++)
        {

            GameObject g = Instantiate(partsPrefab, Pos, Quaternion.identity);

            g.transform.SetParent(partsParent.transform, false);

            g.GetComponent<partsPanel>().steeringFinPart = allPartsOwned.steeringFinPartsOwned[i];
            g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allPartsOwned.steeringFinPartsOwned[i].weight.ToString();
            g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allPartsOwned.steeringFinPartsOwned[i].powerNeeded.ToString();

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
        for (int i = 0; i < allPartsOwned.controlSystemPartsOwned.Count; i++)
        {

            GameObject g = Instantiate(partsPrefab, Pos, Quaternion.identity);

            g.transform.SetParent(partsParent.transform, false);

            g.GetComponent<partsPanel>().controlSystemPart = allPartsOwned.controlSystemPartsOwned[i];
            g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allPartsOwned.controlSystemPartsOwned[i].weight.ToString();
            g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allPartsOwned.controlSystemPartsOwned[i].powerNeeded.ToString();

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
        for (int i = 0; i < allPartsOwned.weaponSystemPartsOwned.Count; i++)
        {

            GameObject g = Instantiate(partsPrefab, Pos, Quaternion.identity);

            g.transform.SetParent(partsParent.transform, false);

            g.GetComponent<partsPanel>().weaponSystemPart = allPartsOwned.weaponSystemPartsOwned[i];
            g.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = allPartsOwned.weaponSystemPartsOwned[i].weight.ToString();
            g.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = allPartsOwned.weaponSystemPartsOwned[i].powerNeeded.ToString();

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
    }*/
}
