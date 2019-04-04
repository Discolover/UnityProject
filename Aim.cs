using UnityEngine;
//to do:
//encapsulate all this in several scripts
//try to remove abs
//move LineRenderer to the scene insted of script?
//initial angle direction of aimLine is consisten with next frame? Is the rough change between states? 
public class Aim : MonoBehaviour {
    public Material ink;
    public float angle;
    public int wc_len = 2;
    public float step = 18.0f;
    float minWidth = 0.2f;
    float limGrow = 0.7f;
    float limit = 0;
    bool isUp = true;
    LineRendererLine aimLine;
    GameObject auxObj;

    float limTop = 180, limBot = 0;
    void Start () {
        CreateChildAuxiliaryObj();       
        InitAimLine();
    }
	void Update () {
        UpdateAimLinePoints();
        AssignAngleBetweenParentAndAuxObjs();
        CheckAngleAndChangeLimit();
        ChangeAngle();
        ChangeStepDependOnLim();
        if (LimWidth() < minWidth)
            RemoveMovement();
    }
    //
    void CreateChildAuxiliaryObj(){
        auxObj = new GameObject("auxObject");
        Vector3 v = new Vector3();
        v = this.transform.position;
        v.x = v.x + wc_len;
        auxObj.transform.position = v;
        auxObj.transform.SetParent(this.transform);
    }
    void InitAimLine(){
        Vector3 startPoint = this.transform.position;
        Vector3 endPoint = auxObj.transform.position;
        aimLine = new LineRendererLine(startPoint, endPoint, ink, 0.05f);
    }
    void UpdateAimLinePoints(){
        aimLine.StartPoint = this.transform.position;
        aimLine.EndPoint = auxObj.transform.position;      
    }
    void AssignAngleBetweenParentAndAuxObjs(){
        Vector3 v = new Vector3();
        v.x = wc_len * Mathf.Sin(Mathf.Deg2Rad * angle);
        v.y = wc_len * Mathf.Cos(Mathf.Deg2Rad * angle);
        auxObj.transform.localPosition = v;
    }
    void CheckAngleAndChangeLimit(){
        
        if (isUp){
            if (angle <= limit){
                isUp = false;
                limit = 180 - limit;
                limit -= limGrow;
                limTop = limit;
            }
        }else{
            if (angle >= limit){
                isUp = true;
                limit = 180 - limit;
                limit += limGrow;
                limBot = limit;
            }
        }
        
    }
    void ChangeAngle(){ 
        if (isUp)
        {
            angle -= step;
        }
        else
        {
            angle += step;
        }
    }
    float LimWidth(){
        return Mathf.Abs(limTop - limBot);
    }
    void  ChangeStepDependOnLim(){
        step = LimWidth()/10;
    }
    void RemoveMovement(){
        limGrow = 0;
        step = 0;
        angle = 90;
    }
}
