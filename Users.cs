public abstract class User{
    protected string uId;
    protected string passWord;
    //public abstract bool login(string id, string pw);
    
    public string getUid(){ return uId;}
    public  bool login(string id, string pw){
       return (uId.Equals(id) && passWord.Equals(pw));

    
}
}