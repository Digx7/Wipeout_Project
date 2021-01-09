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
                                      inventoryPannel,
                                      statsReadOutPannel,
                                      launchPannel,
                                      trackSelectionPannel;

  // G System UI
  [Space]
  [SerializeField] private TextMeshProUGUI gText;

  // Track Selection UI
  [SerializeField] private TextMeshProUGUI trackNameText;
  [SerializeField] private TextMeshProUGUI trackTypeText;

  private Image[] allImages;

  public void UpdateColors(){
    foreach(Image image in allImages) image.color = panelColor;
  }

  public void FindAllImages(){
    allImages = Resources.FindObjectsOfTypeAll<Image>();
  }

  // G System Functions
  public void UpdateGText (string update)
  {
    gText.text = "G: " + update;
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

  public void OpenInventory (){
    UpdateInventoryRendering(true);
  }

  public void CloseInventory (){
    UpdateInventoryRendering(false);
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
}
