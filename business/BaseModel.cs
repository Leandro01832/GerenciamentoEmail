using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
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

        public static BD banco = new BD();

        public static List<BaseModel> modelos = new List<BaseModel>();

        public void Salvar()
        {
            if (this is Admin)          { var modelo = (Admin)this;           banco.Admin.Add(modelo); }
            if (this is Atendente)      { var modelo = (Atendente)this;       banco.Atendente.Add(modelo); }
            if (this is PessoaPF)       { var modelo = (PessoaPF)this;        banco.PessoaPF.Add(modelo); }
            if (this is PessoaPJ)       { var modelo = (PessoaPJ)this;        banco.PessoaPJ.Add(modelo); }
            if (this is Terceiros)      { var modelo = (Terceiros)this;       banco.Terceiros.Add(modelo); }
            if (this is EmailAdvocacia) { var modelo = (EmailAdvocacia)this;  banco.EmailAdvocacia.Add(modelo); }
            if (this is EmailCliente)   { var modelo = (EmailCliente)this;    banco.EmailCliente.Add(modelo); }
            if (this is Permissao)      { var modelo = (Permissao)this;       banco.Permissao.Add(modelo); }

            banco.SaveChanges();
        }

        public void Alterar()
        {
            if (this is Admin) { var modelo = (Admin)this;                   banco.Entry(modelo).State = EntityState.Modified; }
            if (this is Atendente) { var modelo = (Atendente)this;           banco.Entry(modelo).State = EntityState.Modified; }
            if (this is PessoaPF) { var modelo = (PessoaPF)this;             banco.Entry(modelo).State = EntityState.Modified; }
            if (this is PessoaPJ) { var modelo = (PessoaPJ)this;             banco.Entry(modelo).State = EntityState.Modified; }
            if (this is Terceiros) { var modelo = (Terceiros)this;           banco.Entry(modelo).State = EntityState.Modified; }
            if (this is EmailAdvocacia) { var modelo = (EmailAdvocacia)this; banco.Entry(modelo).State = EntityState.Modified; }
            if (this is EmailCliente) { var modelo = (EmailCliente)this;     banco.Entry(modelo).State = EntityState.Modified; }
            if (this is Permissao) { var modelo = (Permissao)this; banco.Entry(modelo).State = EntityState.Modified; }

            banco.SaveChangesAsync();
        }

        public void Excluir()
        {
            if (this is Admin) { var modelo = (Admin)this;                   banco.Admin.Remove(modelo); }
            if (this is Atendente) { var modelo = (Atendente)this;           banco.Atendente.Remove(modelo); }
            if (this is PessoaPF) { var modelo = (PessoaPF)this;             banco.PessoaPF.Remove(modelo); }
            if (this is PessoaPJ) { var modelo = (PessoaPJ)this;             banco.PessoaPJ.Remove(modelo); }
            if (this is Terceiros) { var modelo = (Terceiros)this;           banco.Terceiros.Remove(modelo); }
            if (this is EmailAdvocacia) { var modelo = (EmailAdvocacia)this; banco.EmailAdvocacia.Remove(modelo); }
            if (this is EmailCliente) { var modelo = (EmailCliente)this; banco.EmailCliente.Remove(modelo); }
            if (this is Permissao) { var modelo = (Permissao)this; banco.Permissao.Remove(modelo); }

            banco.SaveChangesAsync();
        }

        public async Task<BaseModel> Recuperar(int Id)
        {
            if (this is Admin)          { return await banco.Admin.FirstOrDefaultAsync(m => m.Id == Id); }
            if (this is Atendente)      { return await banco.Atendente.FirstOrDefaultAsync(m => m.Id == Id); }
            if (this is PessoaPF)       { return await banco.PessoaPF.FirstOrDefaultAsync(m => m.Id == Id); }
            if (this is PessoaPJ)       { return await banco.PessoaPJ.FirstOrDefaultAsync(m => m.Id == Id); }
            if (this is Terceiros)      { return await banco.Terceiros.FirstOrDefaultAsync(m => m.Id == Id); }
            if (this is EmailAdvocacia) { return await banco.EmailAdvocacia.FirstOrDefaultAsync(m => m.Id == Id); }
            if (this is EmailCliente)   { return await banco.EmailCliente.FirstOrDefaultAsync(m => m.Id == Id); }
            if (this is Permissao)      { return await banco.Permissao.FirstOrDefaultAsync(m => m.Id == Id); }

            return null;
        }

        public static async Task<List<BaseModel>> Recuperar()
        {
             modelos.AddRange( await banco.Admin.ToListAsync()); 
             modelos.AddRange( await banco.Atendente.ToListAsync()); 
             modelos.AddRange( await banco.PessoaPF.ToListAsync()); 
             modelos.AddRange( await banco.PessoaPJ.ToListAsync()); 
             modelos.AddRange( await banco.Terceiros.ToListAsync()); 
             modelos.AddRange( await banco.EmailAdvocacia.ToListAsync()); 
             modelos.AddRange( await banco.EmailCliente.ToListAsync()); 
             modelos.AddRange( await banco.Permissao.ToListAsync()); 

            return modelos;
        }
    }
}
