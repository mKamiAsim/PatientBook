using PatientBook.Model.Info;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL.IDapper
{
    public interface IPatientDapperRepo : IDapper
    {
        List<Patient> GetAll();

        void Update(Patient patiend);
    }
}
