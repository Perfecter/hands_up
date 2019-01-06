using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroTest : MonoBehaviour
{
    void Start()
    {
        Input.gyro.enabled = true;
        
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;
        GUILayout.Label("Orientation: " + Screen.orientation);
        var up = Quaternion.LookRotation(Vector3.up);
        var down = Quaternion.LookRotation(Vector3.down);
        var forward = Quaternion.LookRotation(Vector3.forward);
        var backward = Quaternion.LookRotation(Vector3.back);
        var right = Quaternion.LookRotation(Vector3.right);
        var left = Quaternion.LookRotation(Vector3.left);

        Quaternion[] quats = new []{up,down,forward,backward,right,left};

        Quaternion? min = null;
        float angle = 0;
        var quat = GyroToUnity(Input.gyro.attitude);

        foreach (var quaternion in quats)
        {
            var angle2 = Quaternion.Angle(quaternion, quat);

            if (!min.HasValue || angle < angle2)
            {
                min = quaternion;
                angle = angle2;
            }
        }

        GUILayout.Label("Rotation: " + min.Value.eulerAngles);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
