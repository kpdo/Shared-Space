using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Uploads 3d models such as .obj into the scene from an sql database in JSON format.
public class ObjectImporter : MonoBehaviour
{

    //Grabs the JSON object from a url and converts it into a Mesh
    public Mesh GetObjectMesh(string url)
    {
        WWW web = new WWW(url);
        string jsonString = web.text;

        List<Vector3> vertices = JsonUtility.FromJson<List<Vector3>>(jsonString);



        Mesh toReturn = new Mesh();
        toReturn.SetVertices(vertices);

        return toReturn;
    }

}
