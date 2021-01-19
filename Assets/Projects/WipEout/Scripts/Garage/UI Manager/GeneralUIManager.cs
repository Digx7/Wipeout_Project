﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
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
                                      store_PartsPannel,
                                      store_ColorsPannel,
                                      inventoryPannel,
                                      statsReadOutPannel,
                                      launchPannel,
                                      trackSelectionPannel;

  // loadOutPannel Parts
  [Space]
  [SerializeField] private List<GameObject> loadOutPannelParts,
                                            statsPannelText,
                                            inventory_items;

  // Prefabs
  [SerializeField] private GameObject inventoryObjectPrefab;

  // G System UI
  [Space]
  [SerializeField] private TextMeshProUGUI gText;

  // Track Selection UI
  [SerializeField] private TextMeshProUGUI trackNameText;
  [SerializeField] private TextMeshProUGUI trackTypeText;

  // References
  [SerializeField] private AllParts allParts;
  [SerializeField] private AllPartsOwned allPartsOwned;
  [SerializeField] private SystemManager systemManager;
  [SerializeField] private overviewManager overviewManager;
  [SerializeField] private StoreManager storeManager;
  [SerializeField] private GameObject inventory_items_parent;

  private Image[] allImages;
  private GameObject[] allPanels;
  private int UIState;

  // Editor Functions ------------------------------------------

  public void UpdateColors(string input = "Panel"){
    foreach(Image image in allImages) {
      if(image.gameObject.name == input)
      image.color = panelColor;
    }
  }

  public void FindAllImages(){
    allImages = Resources.FindObjectsOfTypeAll<Image>();
  }

  // G System Functions ------------------------------------------

  public void UpdateGText (string update)
  {
    gText.text = update;
  }

  // loadOutPannel and StatsPannel Functions ------------------------------------------

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

  // Inventory Parts Functions ------------------------------------------

  // Owned

  public void OnClickEquipedFramePart (){
    OpenInventory();
    foreach(part part in allPartsOwned.framePartsOwned) {
      loadInventory(part);
      getItemButton(inventory_items.Count - 1).onClick.AddListener(() => overviewManager.NewFramePart(part as frame_part));
    }
  }

  public void OnClickEquipedEnginePart (){
    OpenInventory();
    foreach(part part in allPartsOwned.enginePartsOwned) {
      loadInventory(part);
      getItemButton(inventory_items.Count - 1).onClick.AddListener(() => overviewManager.NewEnginePart(part as engine_part));
    }
  }

  public void OnClickEquipedThrusterPart (){
    OpenInventory();
    foreach(part part in allPartsOwned.thrusterPartsOwned) {
      loadInventory(part);
      getItemButton(inventory_items.Count - 1).onClick.AddListener(() => overviewManager.NewThrusterPart(part as thruster_part));
    }
  }

  public void OnClickEquipedSteeringFinPart (){
    OpenInventory();
    foreach(part part in allPartsOwned.steeringFinPartsOwned) {
      loadInventory(part);
      getItemButton(inventory_items.Count - 1).onClick.AddListener(() => overviewManager.NewSteeringFinPart(part as steeringfin_part));
    }
  }

  public void OnClickEquipedControlPart (){
    OpenInventory();
    foreach(part part in allPartsOwned.controlSystemPartsOwned) {
      loadInventory(part);
      getItemButton(inventory_items.Count - 1).onClick.AddListener(() => overviewManager.NewControlSystemPart(part as controlsystem_part));
    }
  }

  public void OnClickEquipedWeaponPart (){
    OpenInventory();
    foreach(part part in allPartsOwned.weaponSystemPartsOwned) {
      loadInventory(part);
      getItemButton(inventory_items.Count - 1).onClick.AddListener(() => overviewManager.NewWeaponSystemPart(part as weaponsystem_part));
    }
  }

  // Store

  public void OnClickStoreFramePart (){
    OpenInventory();
    foreach(part part in allParts.frameParts) {
      if(!part.isOwned) {
        loadInventory(part);
        getItemButton(inventory_items.Count - 1).onClick.AddListener(() => storeManager.buyPart(part));
      }
    }
  }

  public void OnClickStoreEnginePart (){
    OpenInventory();
    foreach(part part in allParts.engineParts) {
      if(!part.isOwned) {
        loadInventory(part);
        getItemButton(inventory_items.Count - 1).onClick.AddListener(() => storeManager.buyPart(part));
      }
    }
  }

  public void OnClickStoreThrusterPart (){
    OpenInventory();
    foreach(part part in allParts.thrusterParts) {
      if(!part.isOwned) {
        loadInventory(part);
        getItemButton(inventory_items.Count - 1).onClick.AddListener(() => storeManager.buyPart(part));
      }
    }
  }

  public void OnClickStoreSteeringFinsPart (){
    OpenInventory();
    foreach(part part in allParts.steeringFinParts) {
      if(!part.isOwned) {
        loadInventory(part);
        getItemButton(inventory_items.Count - 1).onClick.AddListener(() => storeManager.buyPart(part));
      }
    }
  }

  public void OnClickStoreControlSystemPart (){
    OpenInventory();
    foreach(part part in allParts.controlSystemParts) {
      if(!part.isOwned) {
        loadInventory(part);
        getItemButton(inventory_items.Count - 1).onClick.AddListener(() => storeManager.buyPart(part));
      }
    }
  }

  public void OnClickStoreWeaponSystmePart (){
    OpenInventory();
    foreach(part part in allParts.weaponSystemParts) {
      if(!part.isOwned) {
        loadInventory(part);
        getItemButton(inventory_items.Count - 1).onClick.AddListener(() => storeManager.buyPart(part));
      }
    }
  }

  // General

  private void loadInventory (part part){
    GameObject item = Instantiate(inventoryObjectPrefab, inventory_items_parent.transform);
    inventory_items.Add(item);

    getItemButton(inventory_items.Count - 1).onClick.AddListener(() => OpenParts());
    getItemButton(inventory_items.Count - 1).onClick.AddListener(() => systemManager.Save());

    UpdateItem(inventory_items.Count - 1, part.weight.ToString(), part.powerNeeded.ToString(), part.price.ToString());
  }

  private void ClearInventory (){
    foreach(GameObject item in inventory_items) Destroy(item);
    inventory_items.Clear();
  }

  private void UpdateItem (int index, string weight, string power, string price){
    UpdateItemPower(index, power);
    UpdateItemWeight(index, weight);
    UpdateItemPrice(index, price);
  }

  private Button getItemButton (int index){
    return inventory_items[index].GetComponentInChildren<Button>();
  }

  private void UpdateItemPrice (int index, string value){
    if(UIState == 3)UpdateItemString(index, "Item Price", value);
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

  // Track Selection Functions ------------------------------------------

  public void UpdateAllTrackText (string trackName, string trackType){
    trackNameText.text = trackName;
    trackTypeText.text = trackType;
  }

  public void UpdateTrackNameText (string trackName){
    trackNameText.text = trackName;
  }

  public void UpdateTrackTypeText (string trackType){
    trackNameText.text = trackType;
  }

  // UI States ------------------------------------------

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
    UpdateLoadOutPartsRendering(false);
    UpdateLoadOutColorsRendering(false);
    UpdateStorePartsRendering(false);
    UpdateStoreColorsRendering(false);
    UpdateInventoryRendering(true);
  }

  public void CloseInventory (){
    UpdateInventoryRendering(false);
  }

  public void OpenParts (){
    if(UIState == 3){
      UpdateLoadOutPartsRendering(false);
      UpdateLoadOutColorsRendering(false);
      UpdateStorePartsRendering(true);
      UpdateStoreColorsRendering(false);
      UpdateInventoryRendering(false);
      ClearInventory();
    }
    else {
      UpdateLoadOutPartsRendering(true);
      UpdateLoadOutColorsRendering(false);
      UpdateStorePartsRendering(false);
      UpdateStoreColorsRendering(false);
      UpdateInventoryRendering(false);
      ClearInventory();
    }
  }

  public void OpenColors (){
    if(UIState == 3){
      UpdateLoadOutPartsRendering(false);
      UpdateLoadOutColorsRendering(false);
      UpdateStorePartsRendering(false);
      UpdateStoreColorsRendering(true);
      UpdateInventoryRendering(false);
      ClearInventory();
    }
    else {
      UpdateLoadOutPartsRendering(false);
      UpdateLoadOutColorsRendering(true);
      UpdateStorePartsRendering(false);
      UpdateStoreColorsRendering(false);
      UpdateInventoryRendering(false);
      ClearInventory();
    }
  }

  private void ClosePartsAndColors (){
    UpdateLoadOutPartsRendering(false);
    UpdateLoadOutColorsRendering(false);
  }

  private void UpdateUIState(int input){
    UIState = input;

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
        OpenParts();
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
        OpenParts();
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
        OpenParts();
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

  // Update Rendering of Panels ------------------------------------------

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

  private void UpdateStorePartsRendering(bool input){
    store_PartsPannel.SetActive(input);
  }

  private void UpdateStoreColorsRendering(bool input){
    store_ColorsPannel.SetActive(input);
  }
}
