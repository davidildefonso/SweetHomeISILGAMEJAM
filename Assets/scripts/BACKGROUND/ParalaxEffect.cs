using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    [SerializeField] public float ParalaxxEfectMuliply;
    private Transform CamaraTransform;
    private Vector3 lastposCamera;
    private float UnitSizeX;
    private float UnitSIzeY;
    [SerializeField] private bool IsVertical;
    // Start is called before the first frame update
    public void Start()
    {
        CamaraTransform = Camera.main.transform;
        lastposCamera = CamaraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        UnitSizeX = texture.width / sprite.pixelsPerUnit;
        UnitSIzeY = texture.height / sprite.pixelsPerUnit;

    }

    private void LateUpdate()
    {

        Vector3 deltamovement = CamaraTransform.position - lastposCamera;
        transform.position += new Vector3(deltamovement.x * ParalaxxEfectMuliply, deltamovement.y * ParalaxxEfectMuliply, 0);
        lastposCamera = CamaraTransform.position;
        if (!IsVertical)
        {
            if (Mathf.Abs(CamaraTransform.position.x - transform.position.x) >= UnitSizeX)
            {

                float offsetPosition = (CamaraTransform.position.x - transform.position.x) % UnitSizeX;
                transform.position = new Vector3(CamaraTransform.position.x + offsetPosition, transform.position.y);
            }
        }
        if (IsVertical)
        {
            if (Mathf.Abs(CamaraTransform.position.y - transform.position.y) >= UnitSIzeY)
            {

                float offsetPosition = (CamaraTransform.position.y - transform.position.y) % UnitSIzeY;
                transform.position = new Vector3(transform.position.x, CamaraTransform.position.y + offsetPosition);
            }
        }

    }
}
