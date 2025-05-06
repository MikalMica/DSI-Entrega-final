using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapHandler : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement playerPos = root.Q("legendInfo1");
        playerPos.AddManipulator(new PlayerPosManipulator(root));

        VisualElement mainMission = root.Q("legendInfo2");
        mainMission.AddManipulator(new MainMissionManipulator(root));

        VisualElement undiscovered = root.Q("legendInfo3");
        undiscovered.AddManipulator(new UndiscoveredManipulator(root));

        VisualElement secondary = root.Q("legendInfo4");
        secondary.AddManipulator(new SecondaryMissionManipulator(root));

        VisualElement dangerous = root.Q("legendInfo5");
        dangerous.AddManipulator(new DangerousManipulator(root));
    }
}
