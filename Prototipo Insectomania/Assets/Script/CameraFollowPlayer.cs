using UnityEngine;

namespace Script
{
    public class CameraFollowPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        [SerializeField] private float sensibility = 3;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            var vec = player.transform.position;
            vec.z = vec.z / sensibility;
            var position = transform.position;
            vec.y = position.y;
            vec.x = position.x;
            transform.position = vec;
        }
    }
}
