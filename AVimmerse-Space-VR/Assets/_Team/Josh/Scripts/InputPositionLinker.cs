using UnityEngine;

/// <summary>
/// XR systems origins do not audomitically link.
/// This system links both origins together to prevent the user blipping between system locations.
/// </summary>
public class InputPositionLinker : MonoBehaviour
{
    [SerializeField] private Transform origin1;
    [SerializeField] private Transform origin2;

    [SerializeField] private Vector3 latePos1;
    [SerializeField] private Vector3 latePos2;

    private void Start()
    {
        UpdatePositions();
    }

    private void Update()
    {
        if (origin1.position == origin2.position)
            return; // Nothing's moved

        if (origin1.parent.gameObject.activeSelf)
        {
            print("origin1 active");

            origin1.position = origin2.position; // Move the unmoved to the moved
            print("origin1 alliging to origin2");



            //if (latePos1 != origin1.position)
            //{
            //    print("origin1 has moved.");
            //}
        }
        else if (origin2.parent.gameObject.activeSelf)
        {
            print("origin2 active");

            origin2.position = origin1.position; // move the unmoved to the moved
            print("origin2 alliging to origin1");

            //if (latePos2 != origin2.position)
            //{
            //    print("origin2 has moved.");
            //}
        }

        UpdatePositions();
    }

    private void UpdatePositions()
    {
        latePos1 = origin1.position;
        latePos2 = origin2.position;
    }
}
