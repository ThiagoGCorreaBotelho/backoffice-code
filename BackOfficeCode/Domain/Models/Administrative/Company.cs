using Domain.Configure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Models.Administrative.Company;

namespace Domain.Models.Administrative
{
    public partial class Company : spGetCompany
    {
        #region Internal Parameters

        private readonly Repository _repository;
        private string Entity { get { return "Company"; } }
        public string User { get; set; }
        public string Token { get; set; }

        #endregion

        #region Builders

        public Company()
        {
            User = string.Empty;
            Token = string.Empty;
        }

        public Company(string user, string token)
        {
            User = user;
            Token = token;
        }

        public Company(Repository repository, string user, string token)
        {
            _repository = repository;
            User = user;
            Token = token;
        }

        #endregion

        #region Calls CRUD 

        public async Task<Company> Load(long id)
        {
            var company = await _repository.Consult<Company>(Entity, id, User, Token);

            return company;
        }

        public async Task<T> LoadGeneric<T>(long id, string call)
        {
            return await _repository.Consult<T>(Entity, call, id, User, Token);
        }

        #endregion

    }

    #region Properties

    public class spGetCompany
    {
        [Key]
        [Required(ErrorMessage = "* Obrigatório")]
        [Display(Name = "Id")]
        public long IdCompany { get; set; }

        [Required(ErrorMessage = "* Obrigatório")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string FantasyName { get; set; }

        [Required(ErrorMessage = "* Obrigatório")]
        [Display(Name = "Responsável")]
        public string Responsable { get; set; }

        [Required(ErrorMessage = "* Obrigatório")]
        [Display(Name = "CPF/CNPJ")]
        public string CPFCNPJ { get; set; }

        [Display(Name = "IE")]
        public string IE { get; set; }

        [Display(Name = "Imagem")]
        public string Image { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Criado Por")]
        public string CreatedBy { get; set; }

        [Display(Name = "Modificado Por")]
        public string ChangedBy { get; set; }

        [Display(Name = "Data de criação")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Data de modificação")]
        public DateTime ChangeDate { get; set; }

        [Display(Name = "Ativo")]
        public bool Active { get; set; }

    }

    public class spGetListCompany
    {
        [Key]
        [Required(ErrorMessage = "* Obrigatório")]
        [Display(Name = "Id")]
        public long IdCompany { get; set; }

        [Required(ErrorMessage = "* Obrigatório")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string FantasyName { get; set; }

        [Required(ErrorMessage = "* Obrigatório")]
        [Display(Name = "Responsável")]
        public string Responsable { get; set; }

        [Required(ErrorMessage = "* Obrigatório")]
        [Display(Name = "CPF/CNPJ")]
        public string CPFCNPJ { get; set; }

        [Display(Name = "IE")]
        public string IE { get; set; }

        [Display(Name = "Imagem")]
        public string Image { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }

    #endregion
}
