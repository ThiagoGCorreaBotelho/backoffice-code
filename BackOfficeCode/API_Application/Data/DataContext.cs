using Domain.Models.Administrative;
using Domain.Models.Settings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
                         : base(options)
        {
            Database.SetCommandTimeout(150000);
        }

        #region Validate Token

        private DbSet<spValidateToken> spValidateToken { get; set; }

        public bool TokenValidation(string token, string user)
        {

            var returnValue = this.spValidateToken.FromSqlInterpolated($"Exec Administrative.spValidateTokenUser {token}, {user} ").AsEnumerable().FirstOrDefault();

            return returnValue.Exist;

        }

        #endregion

        #region Comuns

        private DbSet<ReturnId> ReturnId { get; set; }

        #endregion

        #region Company

        private DbSet<spGetListCompany> spGetListCompany { get; set; }
        private DbSet<spGetCompany> spGetCompany { get; set; }

        public List<spGetListCompany> GetListCompany(string user, string filter)
        {
            return spGetListCompany.FromSqlInterpolated($"Exec Administrative.spGetListCompany {user}, {filter}").AsEnumerable().ToList();
        }

        public spGetCompany GetCompany(long id, string user)
        {
            return spGetCompany.FromSqlInterpolated($"Exec Administrative.spGetCompany {id}, {user}").AsEnumerable().FirstOrDefault();
        }

        public spGetCompany InsertCompany(Company company)
        {
            var returnValue = ReturnId.FromSqlInterpolated($"Exec Administrative.spInsertCompany {company.Name}, {company.FantasyName}, {company.Responsable}, {company.CPFCNPJ}, {company.IE}, {company.Image}, {company.Email}, {company.User}").AsEnumerable().FirstOrDefault();

            company.IdCompany = (long)returnValue.Id;

            return company;
        }

        public string ChangeCompany(Company company)
        {
            try
            {
                Database.ExecuteSqlInterpolated($"Exec Administrative.spChangeCompany {company.IdCompany}, {company.Name}, {company.FantasyName}, {company.Responsable}, {company.CPFCNPJ}, {company.IE}, {company.Image}, {company.Email}, {company.User}");

                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }

        public string InactivateCompany(long id, string user)
        {
            try
            {
                Database.ExecuteSqlInterpolated($"Exec Administrative.spInactivateCompany {id}, {user}");

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        #endregion

        #region Sector

        private DbSet<spGetListSector> spGetListSector { get; set; }
        private DbSet<spGetSector> spGetSector { get; set; }

        public List<spGetListSector> GetListSector(string user, string filter)
        {
            return spGetListSector.FromSqlInterpolated($"Exec Administrative.spGetListSector {user}, {filter}").AsEnumerable().ToList();
        }

        public spGetSector GetSector(long id, string user)
        {
            return spGetSector.FromSqlInterpolated($"Exec Administrative.spGetSector {id}, {user}").AsEnumerable().FirstOrDefault();
        }

        public spGetSector InsertSector(Sector sector)
        {
            var returnValue = ReturnId.FromSqlInterpolated($"Exec Administrative.spInsertSector {sector.IdCompany}, {sector.Name}, {sector.User}").AsEnumerable().FirstOrDefault();

            sector.IdSector = (long)returnValue.Id;

            return sector;
        }

        public string ChangeSector(Sector sector)
        {
            try
            {
                Database.ExecuteSqlInterpolated($"Exec Administrative.spChangeSector {sector.IdSector}, {sector.Name}, {sector.User}");

                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }

        public string InactivateSector(long id, string user)
        {
            try
            {
                Database.ExecuteSqlInterpolated($"Exec Administrative.spInactivateSector {id}, {user}");

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }


        #endregion




    }
}
