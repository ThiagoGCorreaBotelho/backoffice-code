using Domain.Configure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Administrative
{
    public partial class Sector : spGetSector
    {
        #region Internal Parameters

        private readonly Repository _repository;
        private string Entity { get { return "Sector"; } }
        public string User { get; set; }
        public string Token { get; set; }

        #endregion

        #region Builders

        public Sector()
        {
            User = string.Empty;
            Token = string.Empty;
        }

        public Sector(string user, string token)
        {
            User = user;
            Token = token;
        }

        public Sector(Repository repository, string user, string token)
        {
            _repository = repository;
            User = user;
            Token = token;
        }


        #region CRUD

        public async Task<Sector> Load(long id)
        {

            var sector = await _repository.Consult<Sector>(Entity, id, User, Token);

            return sector;

        }

        public async Task<T> LoadGeneric<T>(long id, string call)
        {
            return await _repository.Consult<T>(Entity, call, id, User, Token);
        }

        public async Task<List<Sector>> LoadList(string filter)
        {
            return await _repository.ConsultList<Sector>(Entity, filter, User, Token);
        }

        public async Task<List<T>> LoadListGeneric<T>(long id, string call, string filter)
        {
            return await _repository.ConsultList<T>(Entity, call, id, filter, User, Token);
        }

        public async Task<Sector> Insert(Sector sector)
        {
            return await _repository.Insert<Sector>(Entity, sector);
        }

        public async Task<bool> Change(long id, Sector sector)
        {
            return await _repository.Change<Sector>(Entity, id, sector);
        }

        public async Task<bool> Inativate(long id, Sector sector)
        {
            return await _repository.Inactivate<Sector>(Entity, id, sector);
        }

        #endregion

        #endregion
    }

    #region Properties

    public class spGetSector
    {
        [Key]
        [Required(ErrorMessage = "* Obrigatório")]
        [Display(Name = "Id")]
        public long IdSector { get; set; }

        [Required(ErrorMessage = "* Obrigatório")]
        [Display(Name = "Id Company")]
        public long IdCompany { get; set; }

        [Required(ErrorMessage = "* Obrigatório")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Criador Por")]
        public string CreateBy { get; set; }

        [Display(Name = "Modificado Por")]
        public string ChangedBy { get; set; }

        [Display(Name = "Data Criação")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Data Modificação")]
        public DateTime ChangeDate { get; set; }

        [Display(Name = "Ativo")]
        public DateTime Active { get; set; }
    }

    public class spGetListSector
    {
        [Key]
        [Required(ErrorMessage = "* Obrigatório")]
        [Display(Name = "Id")]
        public long IdSector { get; set; }

        [Required(ErrorMessage = "* Obrigatório")]
        [Display(Name = "Id Company")]
        public long IdCompany { get; set; }

        [Required(ErrorMessage = "* Obrigatório")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
    }

  

    #endregion
}
