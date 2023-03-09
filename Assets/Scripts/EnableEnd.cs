using UnityEngine;

    public class EnableEnd : MonoBehaviour
    {
        public GameObject[] ending;
        public void OnTriggerEnter(Collider capsule)
        {
            if (capsule.gameObject.CompareTag("Finish"))
            {
                capsule.gameObject.SetActive(false);
                ending[1].SetActive(true);
                ending[0].gameObject.SetActive(true);
                
            }
        }
    }