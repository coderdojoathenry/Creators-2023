using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour
{
  public TextAsset MapFile;

  // Start is called before the first frame update
  void Start()
  {
    BuildMap();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void BuildMap()
  {
    // Make sure we have a map file
    if (MapFile == null)
    {
      Debug.Log("No map file provided");
      return;
    }

    // Let's see some information about the file
    Debug.Log("We have a map file called " + MapFile.name);
    Debug.Log("The file contents are " + MapFile.text);

    // Lets split the file into lines
    string[] lines = MapFile.text.Split('\n');
    Debug.Log("We have " + lines.Length + " lines in the file");
  }
}
