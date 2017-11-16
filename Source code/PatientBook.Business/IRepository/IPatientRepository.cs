using PatientBook.Model.Info;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientBook.Business.IRepository
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatients();

        Patient Insert(Patient p);
    }
}
