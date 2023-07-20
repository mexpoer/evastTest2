using UnityEngine;
using UnityEngine.UI;

public class Pyramid : MonoBehaviour
{
    public GameObject rectanglePrefab; 
    public Transform rectangleParent;
    public InputField inputField;
    public float rectangleWidth = 30f; 
    public float rectangleHeight = 30f; 

    private void Start()
    {
        Button generateButton = GetComponentInChildren<Button>();
        generateButton.onClick.AddListener(GeneratePyramid);
    }

    private void GeneratePyramid()
    {
        foreach (Transform child in rectangleParent)
        {
            Destroy(child.gameObject);
        }
        if (int.TryParse(inputField.text, out int n) && n > 0)
        {
            //centre
            Vector3 centerPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, Camera.main.nearClipPlane));
            float startX = centerPosition.x;
            float startY = centerPosition.y + ((n - 1) * rectangleHeight / 2f);

            // Creation pyramid
            for (int i = 0; i < n; i++)
            {
                int rowRectangles = n - i;
                float rowStartX = startX - (rowRectangles - 1) * rectangleWidth / 2f;

                for (int j = 0; j < rowRectangles; j++)
                {
                    float x = rowStartX + j * rectangleWidth;
                    float y = startY - i * rectangleHeight;
                    Vector3 position = new Vector3(x, y, 0f);

                    //position
                    GameObject rectangle = Instantiate(rectanglePrefab, position, Quaternion.identity);
                    rectangle.transform.SetParent(rectangleParent);
                }
            }
        }
    }
}

