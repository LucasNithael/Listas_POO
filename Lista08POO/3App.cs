using System;
using System.Collections;


class Program{
  public static void Main(){
    Aplicativo app1 = new Aplicativo{Nome="Whatsapp", Categoria="Comunicação", Preco=0.10};
    Aplicativo app2 = new Aplicativo{Nome="Notion", Categoria="Educação", Preco=5.00};
    Aplicativo app3 = new Aplicativo{Nome="NetFlix", Categoria="Entretenimento", Preco=20.00};
    Aplicativo app4 = new Aplicativo{Nome="Facebook", Categoria="Comunicação", Preco=0.00};
    
  Loja loja = new Loja{Nome="PlayStore"};

    app1.Curtir();
    app1.Curtir();
    app1.Curtir();

    app2.Curtir();
    app2.Curtir();

    app3.Curtir();

    
    
    Console.WriteLine();
    Console.WriteLine($"----Loja {loja.Nome}----");    
    Console.WriteLine();
    
    loja.Inserir(app1);
    loja.Inserir(app2);
    loja.Inserir(app3);
    loja.Inserir(app4);

    //loja.Excluir(app1);
    //loja.Excluir(app4);

    Console.WriteLine("----Lista de APP----");
    //Lista Categoria   
    Array.Sort(loja.Listar());
    foreach(Aplicativo x in loja.Listar())
      Console.WriteLine(x);
    
    Console.WriteLine();
    
    Console.WriteLine("----Lista de Categoria----");
  
    foreach(Aplicativo x in loja.Pesquisar("Comunicação"))
      Console.WriteLine(x);

    Console.WriteLine();
    Console.WriteLine("----Quantidade de APPs----");
    Console.WriteLine(loja.Qtd);

    Console.WriteLine("\n----Lista por preço----");
    foreach(Aplicativo i in loja.ListarPreco())
      Console.WriteLine(i);


     Console.WriteLine("\n----Lista por curtidas----");
    foreach(Aplicativo i in loja.ListarCurtidas())
      Console.WriteLine(i);
    
  }
}




class Loja{
  private Aplicativo[] apps = new Aplicativo[1];
  private int k = 0;
  private int qtd = 0;
  public string Nome{get; set;}
  public int Qtd{get{return qtd;}}
  public void Inserir(Aplicativo app){
    if(k==apps.Length)
      Array.Resize(ref apps, 1 + apps.Length);
    apps[k] = app;
    k++;
    qtd++;
  }
  public void Excluir(Aplicativo app){
    for(int i=0 ; i<k ; i++)
      if(apps[i]==app){
        apps[i] = null; 
      }
    qtd--; 
  }
  public Aplicativo[] Listar(){
    int l=0;
    foreach(Aplicativo i in apps)
      if(i!=null)
        l++;
    Aplicativo[] r = new Aplicativo[l];
    int j=0;
    foreach(Aplicativo i in apps)
      if(i!=null){
        r[j]=i;
        j++;      
      }
    Array.Sort(r);
    return r;
  }
  public Aplicativo[] Pesquisar(string catg){
    int y = 0;
    foreach(Aplicativo i in Listar())
      if(i.Categoria==catg)
        y++;
    
    Aplicativo[] r = new Aplicativo[y];
    int m = 0;
    foreach(Aplicativo i in Listar())
      if(i.Categoria==catg){
        r[m] = i;
        m++;
      }
    
    return r;
  }
  public Aplicativo[] ListarPreco(){
    PrecoComp x = new PrecoComp();
    Aplicativo[] r = new Aplicativo[qtd];
    Array.Copy(Listar(), r, qtd);
    Array.Sort(r, x);
    return r;
  }
  public Aplicativo[] ListarCurtidas(){
    CurtidasComp x = new CurtidasComp();
    Aplicativo[] r = new Aplicativo[qtd];
    Array.Copy(Listar(), r, qtd);
    Array.Sort(r, x);
    return r;
  }
}



class Aplicativo : IComparable{
  private int curtidas;
  public string Nome{get; set;}
  public string Categoria{get; set;}
  public double Preco{get; set;}
  public int Curtidas{get{return curtidas;}}
  public void Curtir(){
    this.curtidas = this.curtidas + 1;
  }
  public int CompareTo(object obj){
    Aplicativo x = (Aplicativo)obj;
    return this.Nome.CompareTo(x.Nome);
  }
  public override string ToString(){
    return $"{Nome} - Categoria: {Categoria} - {Preco:c2} - {curtidas} Curtidas ";
  }
}

class PrecoComp : IComparer {
  public int Compare(object x, object y){
    Aplicativo a = (Aplicativo)x;
    Aplicativo b = (Aplicativo)y;
    return -a.Preco.CompareTo(b.Preco);
  }
}

class CurtidasComp : IComparer {
  public int Compare(object x, object y){
    Aplicativo a = (Aplicativo)x;
    Aplicativo b = (Aplicativo)y;
    return -a.Curtidas.CompareTo(b.Curtidas);
  }
}