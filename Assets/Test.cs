using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Navigation;


public class Test : MonoBehaviour
{
    [SerializeField] private Map map;
    [SerializeField] private GameObject sphere;
    [SerializeField] private GameObject obstacle;

    private Ray FromCameraToMouse => Camera.main.ScreenPointToRay(Input.mousePosition);
    private bool IsLeftButtonDown => Input.GetMouseButtonDown(0);

    private void Update()
    {
        if (IsLeftButtonDown)
        {
            if (Physics.Raycast(FromCameraToMouse, out RaycastHit hit))
            {
                if (hit.transform.CompareTag("Floor")) // <- ?
                    CreateObstacle(hit.point);
            }
        }
    }



    private void CreateObstacle(Vector3 point)
    {
        Instantiate(obstacle, point, Quaternion.identity);
        map.Insert(MapObject.Obstacle, Rounding(new Vector2(point.z, point.x)));
    }

    private Point Rounding(Vector2 point)
    {
        if (point.x < 0)
            point.x = 0;
        else if (point.x >= map.Width)
            point.x = map.Width - 1;

        if (point.y < 0)
            point.y = 0;
        else if (point.y >= map.Height)
            point.y = map.Height - 1;

        return new Point((int)(point.x + 0.5f), (int)(point.y + 0.5f));
    }
}