using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGrid : MonoBehaviour
{
    public Material GLMat;
    public int gridCount = 5; //number of grids to draw on each side of the look position (half size)

    Ray ray;
    float rayDist;
    Vector3 lookPosition;
    Plane world = new Plane(Vector3.up, Vector3.zero); //world plane to draw the grid on
    Camera cam;

    void Start()
    {
        
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        world.Raycast(ray, out rayDist);
        lookPosition = ray.GetPoint(rayDist);
    }

    void OnPostRender()
    {
        GL.PushMatrix();
        GLMat.SetPass(0);
        GL.Begin(GL.LINES);

        Vector3 rounedPos = new Vector3(Mathf.Round(lookPosition.x), 0, Mathf.Round(lookPosition.z));

        //Actual look position
        GL.Color(Color.black);
        GL.Vertex(lookPosition);
        GL.Vertex(lookPosition + Vector3.up);

        GL.Color(Color.white);

        //Major x line
        GL.Vertex(rounedPos + new Vector3(gridCount, 0, 0));
        GL.Vertex(rounedPos + new Vector3(-gridCount, 0, 0));
        //Major z line
        GL.Vertex(rounedPos + new Vector3(0, 0, gridCount));
        GL.Vertex(rounedPos + new Vector3(0, 0, -gridCount));

        GL.Color(Color.red);

        for (int i = 1; i < gridCount + 1; i++)
        {
            //positive x lines
            GL.Vertex(rounedPos + new Vector3(i, 0, gridCount));
            GL.Vertex(rounedPos + new Vector3(i, 0, -gridCount));
            //negative x lines
            GL.Vertex(rounedPos + new Vector3(-i, 0, gridCount));
            GL.Vertex(rounedPos + new Vector3(-i, 0, -gridCount));
            //positive z lines
            GL.Vertex(rounedPos + new Vector3(gridCount, 0, i));
            GL.Vertex(rounedPos + new Vector3(-gridCount, 0, i));
            //negative z lines
            GL.Vertex(rounedPos + new Vector3(gridCount, 0, -i));
            GL.Vertex(rounedPos + new Vector3(-gridCount, 0, -i));


        }

        GL.End();
        GL.PopMatrix();
    }


}
