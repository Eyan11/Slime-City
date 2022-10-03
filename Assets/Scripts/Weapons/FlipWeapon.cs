using UnityEngine;

public class FlipWeapon : MonoBehaviour
{
    [SerializeField] private GameObject rotationPoint;
    void Update()
    {
        if(rotationPoint.GetComponent<Rigidbody2D>().rotation < 0) {
            
            if(rotationPoint.GetComponent<Rigidbody2D>().rotation > -180) {
                
                transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
        }
        if(rotationPoint.GetComponent<Rigidbody2D>().rotation > 0) {
        
            transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
        }
        if(rotationPoint.GetComponent<Rigidbody2D>().rotation < -180) {  
                
            transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
        }
    }
}
