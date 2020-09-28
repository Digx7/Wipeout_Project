using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneralUIManager : MonoBehaviour
{
  // G System UI
  public TextMeshProUGUI gText;

  // Track Selection UI
  public TextMeshProUGUI trackNameText;
  public TextMeshProUGUI trackTypeText;

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
}
