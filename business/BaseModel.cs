using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;

namespace business
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
        }

        [Key]
        public int Id { get; set; }
        public static bool Desktop;
        public static string Operacao = "";

        public static BD banco = new BD();

        public static List<BaseModel> modelos = new List<BaseModel>();

        public void Salvar()
        {
            Operacao = "insert";
            banco.Add(this);
            banco.SaveChanges();
            Operacao = "";
        }

        public void Alterar()
        {
            Operacao = "update";
            banco.Update(this);
            banco.SaveChangesAsync();
            Operacao = "";
        }

        public void Excluir()
        {
            Operacao = "delete";
            banco.Remove(this);
            banco.SaveChangesAsync();
            Operacao = "";
        }

        public async Task<BaseModel> Recuperar(int Id)
        {
            Operacao = "select";
            var objeto = await banco.FindAsync(GetType(), Id);
            Operacao = "";
            if (objeto != null)
            return (BaseModel)objeto;
            return null;             
        }

        public static async Task<List<BaseModel>> Recuperar()
        {
            banco = new BD();

             modelos.AddRange( await banco.Admin.Include(a => a.Permissao).ThenInclude(a => a.Permissao)
                 .Include(a => a.Permissao).ThenInclude(a => a.Funcionario).ToListAsync()); 

             modelos.AddRange( await banco.Atendente.Include(a => a.Permissao).ThenInclude(a => a.Permissao)
                 .Include(a => a.Permissao).ThenInclude(a => a.Funcionario).ToListAsync()); 

             modelos.AddRange( await banco.PessoaPF.Include(a => a.PessoaPJ).ThenInclude(a => a.Clientes).ToListAsync());
            
             modelos.AddRange( await banco.PessoaPJ.Include(a => a.Clientes).ToListAsync()); 

             modelos.AddRange( await banco.Terceiros.Include(a => a.PessoaPJ).ThenInclude(a => a.Clientes).ToListAsync());
            
             modelos.AddRange( await banco.EmailAdvocacia.Include(a => a.Body).Include(a => a.Categoria)
                 .ThenInclude(a => a.Permissao).Include(a => a.Categoria).ThenInclude(a => a.Email)
                 .Include(a => a.Pessoa).ThenInclude(a => a.PessoaPJ).ToListAsync()); 

             modelos.AddRange( await banco.EmailCliente.Include(a => a.Categoria)
                 .ThenInclude(a => a.Permissao).Include(a => a.Categoria).ThenInclude(a => a.Email)
                 .Include(a => a.Atendente).ThenInclude(a => a.Permissao).ThenInclude(a => a.Permissao)
                 .Include(a => a.Atendente).ThenInclude(a => a.Permissao).ThenInclude(a => a.Funcionario).ToListAsync());
            
             modelos.AddRange( await banco.Permissao.Include(a => a.Funcionarios).Include(a => a.Categoria)
                 .ThenInclude(a => a.Email).Include(a => a.Categoria)
                 .ThenInclude(a => a.Permissao).ToListAsync()); 

            return modelos;
        }

        public string MensagemErro(Exception ex)
        {
            string mensagem = "";
            var props = this.GetType().GetProperties();
            foreach (var item in props)
                 if (item.Name == ex.Message)
                {
                    OpcoesBase opc = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

                    if (opc != null && opc.Obrigatorio && item.GetValue(this) == null)
                        mensagem += "Erro no campo " + item.Name + ". Este Campo é Obrigatório.\n";
                    if (ex.Message == "Email")
                        mensagem += "O campo " + item.Name + " precisa ser validado. \n";
                    if (opc != null && opc.Caracteres != 0)
                        mensagem += "O campo " + item.Name + " precisa ter " + opc.Caracteres + " caracteres. \n";
                    if (opc != null && opc.Index && mensagem == "")
                        mensagem += "O campo " + item.Name + " já foi cadastrado. \n";

                }
            return mensagem;
        }
    }
}
