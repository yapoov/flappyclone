using SplashKitSDK;

public class GameObject{
    

    public Transform transform {get;}
    private List<Component> components= new();
    public GameObject(){

        transform = new Transform();
        AddComponent(transform);
    }
    public void Update(float timeDelta){
        foreach(var component in components){
            component.Update(timeDelta);
        }
    }

    public void AddComponent<T>(T comp) where T:Component {
        if(comp.gameObject==this) return;
        components.Add(comp);
        comp.gameObject= this;
    }

    public void AddComponent<T>() where T:Component,new(){
        AddComponent(new T());
    } 
    public T? GetComponent<T>() where T:Component{
        foreach(var comp in components){
            if(comp is T res){
                return res;
            }
        }
        return default;
    }
}