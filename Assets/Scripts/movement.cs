using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    
    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));

    }

    // Update is called once per frame
    void Update()
    {
      transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
      if(Vector2.Distance(transform.position, moveSpot.position)<.2f){
      if(waitTime <= 0){
          moveSpot.position = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
           
      }  else{
          waitTime -= Time.deltaTime;
      }
    }}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag=="spidey"){
          moveSpot.position = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
           Timer.timerValue+=1;
        }
    }

}
