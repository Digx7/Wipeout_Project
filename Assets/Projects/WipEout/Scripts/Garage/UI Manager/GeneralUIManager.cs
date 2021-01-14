using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneralUIManager : MonoBehaviour
{
  // UI elements
  [SerializeField] private Color panelColor;
  [SerializeField] private GameObject gPannel,
                                      windowTabs_1,
                                      windowTabs_2,
                                      settingsPannel,
                                      loadOutPannel,
                                      loadOut_PartsPannel,
                                      loadOut_ColorsPannel,
                                      inventoryPannel,
                                      statsReadOutPannel,
                                      launchPannel,
                                      trackSelectionPannel;

  // loadOutPannel Parts
  [Space]
  [SerializeField] private List<GameObject> loadOutPannelParts,
                                            statsPannelText,
                                            inventory_items;

  // G System UI
  [Space]
  [SerializeField] private TextMeshProUGUI gText;

  // Track Selection UI
  [SerializeField] private TextMeshProUGUI trackNameText;
  [SerializeField] private TextMeshProUGUI trackTypeText;

  // References
  [SerializeField] private AllPartsOwned allPartsOwned;

  private Image[] allImages;
  private GameObject[] allPanels;

  // Editor Functions

  public void UpdateColors(string input = "Panel"){
    foreach(Image image in allImages) {
      if(image.gameObject.name == input)
      image.color = panelColor;
    }
  }

  public void FindAllImages(){
    allImages = Resources.FindObjectsOfTypeAll<Image>();
  }

  // G System Functions
  public void UpdateGText (string update)
  {
    gText.text = update;
  }

  // loadOutPannel and StatsPannel Functions

  public void UpdatePart (int partIndex, string partName, string partWeight, string partPower){
    UpdatePartName(partIndex, partName);
    UpdatePartWeight(partIndex, partWeight);
    UpdatePartPower(partIndex, partPower);

    //Debug.Log("A UI Part pannel was updated to the following : " + partName + " " + partWeight + " " + partPower);
  }

  public void UpdateStat (int index, string statName, string statValue){
    UpdateStatName(index, statName);
    UpdateStatValue(index, statValue);
  }

  private void UpdatePartName (int index, string name){
    UpdatePartString(index, "Part Name", name);
  }

  private void UpdatePartWeight (int index, string value){
    UpdatePartString(index, "Part Weight", value);
  }

  private void UpdatePartPower (int index, string value){
    UpdatePartString(index, "Part Power", value);
  }

  private void UpdateStatName (int index, string input){
    UpdateStatString(index, "Stat Name", input);
  }

  private void UpdateStatValue (int index, string value){
    UpdateStatString (index, "Stat Value", value);
  }

  private void UpdatePartString (int index, string partName, string newText){
    UpdateUIString (loadOutPannelParts, index, partName, newText);
  }

  private void UpdateStatString (int index, string statName, string newText){
    UpdateUIString (statsPannelText, index, statName, newText);
  }

  private void UpdateUIString (List<GameObject> g, int index, string partName, string newText){
    g[index].transform.Find(partName).GetComponent<TextMeshProUGUI>().text = newText;
  }

  // Inventory Parts Functions

  public void loadInventory (string typeToLoad){
    switch (typeToLoad){
      case "Owned_Frame":
        break;
    }
  }

  private void ClearInventory (){
    foreach(GameObject item in inventory_items) Destroy(item);
    inventory_items.Clear();
  }

  private void UpdateItem (int index, string weight, string power){
    UpdateItemPower(index, power);
    UpdateItemWeight(index, weight);
  }

  private void UpdateItemPower (int index, string value){
    UpdateItemString(index, "Item Power", value);
  }

  private void UpdateItemWeight (int index, string value){
    UpdateItemString(index, "Item Weight", value);
  }

  private void UpdateItemString (int index, string objectName, string value){
    UpdateUIString(inventory_items, index, objectName, value);
  }

  // Track Selection Functions
  public void UpdateAllTrackText (string trackName, string trackType)
  {
    trackNameText.text = trackName;
    trackTypeText.text = trackType;
  }
  public void UpdateTrackNameText (string trackName)
  {
    trackNameText.text = trackName;
  }
  public void UpdateTrackTypeText (string trackType)
  {
    trackNameText.text = trackType;
  }

  // UI States

  public void SetToLauchWindow (){
    UpdateUIState(1);
  }

  public void SetToShipEditor (){
    UpdateUIState(2);
  }

  public void SetToShop (){
    UpdateUIState(3);
  }

  public void SetToSettings (){
    UpdateUIState(4);
  }

  public void SetToTrackSelection (){
    UpdateUIState(5);
  }

  public void OpenInventory (){
    UpdateInventoryRendering(true);
  }

  public void CloseInventory (){
    UpdateInventoryRendering(false);
  }

  public void OpenParts (){
    UpdateLoadOutPartsRendering(true);
    UpdateLoadOutColorsRendering(false);
  }

  public void OpenColors (){
    UpdateLoadOutPartsRendering(false);
    UpdateLoadOutColorsRendering(true);
  }

  private void UpdateUIState(int input){
    switch (input){
      case 1 :
        UpdateGRendering(true);
        UpdateWindow1Rendering(true);
        UpdateWindow2Rendering(false);
        UpdateSettingsRendering(true);
        UpdateLoadOutRendering(false);
        UpdateInventoryRendering(false);
        UpdateStatsRendering(false);
        UpdateLaunchRendering(true);
        UpdateTrackSelectionRendering(true);
        break;
      case 2 :
        UpdateGRendering(false);
        UpdateWindow1Rendering(true);
        UpdateWindow2Rendering(true);
        UpdateSettingsRendering(true);
        UpdateLoadOutRendering(true);
        UpdateInventoryRendering(false);
        UpdateStatsRendering(true);
        UpdateLaunchRendering(false);
        UpdateTrackSelectionRendering(false);
        break;
      case 3 :
        UpdateGRendering(true);
        UpdateWindow1Rendering(true);
        UpdateWindow2Rendering(true);
        UpdateSettingsRendering(true);
        UpdateLoadOutRendering(true);
        UpdateInventoryRendering(false);
        UpdateStatsRendering(true);
        UpdateLaunchRendering(false);
        UpdateTrackSelectionRendering(false);
        break;
      case 4 :
        UpdateGRendering(false);
        UpdateWindow1Rendering(false);
        UpdateWindow2Rendering(false);
        UpdateSettingsRendering(false);
        UpdateLoadOutRendering(false);
        UpdateInventoryRendering(false);
        UpdateStatsRendering(false);
        UpdateLaunchRendering(false);
        UpdateTrackSelectionRendering(false);
        break;
      case 5 :
        UpdateGRendering(false);
        UpdateWindow1Rendering(false);
        UpdateWindow2Rendering(false);
        UpdateSettingsRendering(false);
        UpdateLoadOutRendering(false);
        UpdateInventoryRendering(false);
        UpdateStatsRendering(false);
        UpdateLaunchRendering(false);
        UpdateTrackSelectionRendering(false);
        break;
    }
  }

  // Update Rendering of Panels

  private void UpdateGRendering(bool input){
    gPannel.SetActive(input);
  }

  private void UpdateWindow1Rendering(bool input){
    windowTabs_1.SetActive(input);
  }

  private void UpdateWindow2Rendering(bool input){
    windowTabs_2.SetActive(input);
  }

  private void UpdateSettingsRendering(bool input){
    settingsPannel.SetActive(input);
  }

  private void UpdateLoadOutRendering(bool input){
    loadOutPannel.SetActive(input);
  }

  private void UpdateInventoryRendering(bool input){
    inventoryPannel.SetActive(input);
  }

  private void UpdateStatsRendering(bool input){
    statsReadOutPannel.SetActive(input);
  }

  private void UpdateLaunchRendering(bool input){
    launchPannel.SetActive(input);
  }

  private void UpdateTrackSelectionRendering(bool input){
    trackSelectionPannel.SetActive(input);
  }

  private void UpdateLoadOutPartsRendering(bool input){
    loadOut_PartsPannel.SetActive(input);
  }
  private void UpdateLoadOutColorsRendering(bool input){
    loadOut_ColorsPannel.SetActive(input);
  }
}
