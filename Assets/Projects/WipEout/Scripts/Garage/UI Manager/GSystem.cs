using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSystem : MonoBehaviour
{
  public int G;

  public void UpdateG (int change)
  {
    G += change;
  }
}
