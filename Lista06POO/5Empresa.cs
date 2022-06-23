using System;

class MainClass{
  public static void Main(){
    Cliente c1 = new Cliente("Lucas", "200.500.400-12", 200.10);
    Cliente c2 = new Cliente("Nithael", "500.400.200-12", 500.00);
    //Console.WriteLine(c1);
    //Console.WriteLine(c2);
    //Console.WriteLine(c1.GetLimite());
    c1.SetSocio(c2);
    Console.WriteLine(c1.GetLimite());

    Empresa emp = new Empresa();
    emp.Inserir(c1);
    emp.Inserir(c2);

    foreach(Cliente i in emp.Listar())
      Console.WriteLine(i);
  }
}

class Cliente{
  private string nome;
  private string cpf;
  private double limite;
  private Cliente socio;
  public Cliente(string nome, string cpf, double limite){
    this.nome = nome;
    this.cpf = cpf;
    this.limite = limite;
  }
  public void SetSocio(Cliente c){
    this.limite = this.limite + c.GetLimite();
    this.socio = c;
  }
  public double GetLimite(){
    return limite;
  }
  public override string ToString(){
    return $"{nome} {cpf}";
  }
}

class Empresa{
  private Cliente[] clientes = new Cliente[1];
  private int k=0;
  public void Inserir(Cliente c){
    if (k == clientes.Length)
        Array.Resize(ref clientes, 1 + clientes.Length); 
      clientes[k] = c;
      k++;
  }
  public Cliente[] Listar(){
    return clientes;
  }
}
