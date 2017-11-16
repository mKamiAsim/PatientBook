using Persistence.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using PatientBook.Model.Info;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PatientBook.Business.Repository
{
    internal class PatientRepository : Common.BaseRepository, IRepository.IPatientRepository
    {
        PatientDbContext context;
        Persistence.DAL.IDapper.IPatientDapperRepo dapper;
        public PatientRepository(PatientDbContext _context, Persistence.DAL.IDapper.IPatientDapperRepo _dapper)
        {
            context = _context;
            dapper = _dapper;
            Connection = context.Database.GetDbConnection();
            dapper.Connection = Connection;
        }
        public List<Patient> GetAllPatients()
        {
            var dapperList = dapper.GetAll();
            if(dapperList.Count>0)
            {
                foreach(var item in dapperList)
                {
                    item.Address = "Dapper Address";
                }
            }

            var patients= context.Patients.ToList();

            patients.AddRange(dapperList);

            return patients;
        }

        public Patient Insert(Patient p)
        {
            BeginTransaction();

            try
            {
                context.Database.UseTransaction(Transaction as System.Data.Common.DbTransaction);
                dapper.Transaction = Transaction;

                //context.Patients.Attach(p);
                context.Entry<Patient>(p).State = EntityState.Added;
                context.Patients.Add(p);
                context.SaveChanges();

                p.Address = "Updated Address Dpr";

                dapper.Update(p);

                Transaction.Commit();
            }
            catch(Exception ex)
            {
                Transaction.Rollback();
            }
            return p;
        }
    }
}
