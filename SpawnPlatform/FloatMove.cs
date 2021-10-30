
using UnityEngine;

public class FloatMove : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private float _speedFloat = 3f;
    
  
    
    void Update()
    {
        CheckForOutWorld();
        DiractionFloat();      
    }
    private void DiractionFloat()
    {
        transform.Translate(Vector3.down * _speedFloat * Time.deltaTime);
    }
    private void CheckForOutWorld()
    {
        if (transform.position.y < -42)
        {
            gameObject.SetActive(false);
        }
    }
}
