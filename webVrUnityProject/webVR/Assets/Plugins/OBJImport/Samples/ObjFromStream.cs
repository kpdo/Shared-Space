using Dummiesman;
using System.IO;
using System.Text;
using UnityEngine;

public class ObjFromStream : MonoBehaviour {

    public void LoadObject(string url)
    {
        var www = new WWW(url);
        while (!www.isDone)
            System.Threading.Thread.Sleep(1);

        //create stream and load
        var textStream = new MemoryStream(Encoding.UTF8.GetBytes(www.text));
        var loadedObj = new OBJLoader().Load(textStream);
    }
}
