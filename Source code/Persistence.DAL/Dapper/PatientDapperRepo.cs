using System;
using System.Collections.Generic;
using System.Text;
using PatientBook.Model.Info;
using Persistence.DAL.Common;
using Dapper;
using System.Linq;

namespace Persistence.DAL.Dapper
{
    public class PatientDapperRepo : BaseDapper, IDapper.IPatientDapperRepo
    {
        public List<Patient> GetAll()
        {
            return SqlMapper.Query<Patient>(Connection, "SELECT * FROM Patient", commandType: System.Data.CommandType.Text).ToList();
        }

        public void Update(Patient patient)
        {
            string query = $"UPDATE PATIENT SET Address = @Address WHERE PatientId = @PatientId";

            Connection.Query<Patient>(query, patient, Transaction);
        }
    }
}
