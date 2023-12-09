using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour
{
  public TextAsset MapFile;
  public float Size = 4.0f;
  public GameObject FloorPrefab;
  public GameObject WallPrefab;
  public GameObject PillarPrefab;
  public GameObject DoorwayPrefab;

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

    // Loop over the lines
    for (int line = 0; line < lines.Length; line++)
    {
      // Work out the position for the start of the line
      Vector3 lineStart = new Vector3(0, 0, Size * line);

      // Loop over the individual characters of the line
      for (int cpos = 0; cpos < lines[line].Length; cpos++)
      {
        // Work out the position for the piece we're going to place
        Vector3 tilePos = lineStart + new Vector3(Size * cpos * -1, 0, 0);

        // If the character is 0, place a floor, if it is 1, place a wall
        if (lines[line][cpos] == '0')
        {
          // Place a floor
          Instantiate(FloorPrefab, tilePos, Quaternion.identity, transform);
        }
        else if (lines[line][cpos] == '1')
        {
          // Place a wall
          Instantiate(WallPrefab, tilePos, Quaternion.identity, transform);
        }
        else if (lines[line][cpos] == '2')
        {
          // Place a wall
          Instantiate(PillarPrefab, tilePos, Quaternion.identity, transform);
        }
        else if (lines[line][cpos] == '3')
        {
          // Place a wall
          Instantiate(DoorwayPrefab, tilePos, Quaternion.identity, transform);
        }
      }
    }
  }
}
